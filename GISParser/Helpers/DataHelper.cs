namespace GISParser.Helpers
{
	#region Library Imports

	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Configuration;
	using System.Data;
	using System.Data.OleDb;
	using System.Data.SqlClient;
	using System.Diagnostics;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices;
	using System.Security.AccessControl;
	using System.Text;
	using Enumerators;

	#endregion

	public static class DataHelper
	{
		public const string DbfConnectionStringTemplate =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=dBASE IV;";

		public static string DefaultConnectionString
			=> ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

		public static int DefaultBatchSize => int.Parse(ConfigurationManager.AppSettings["DatabaseBatchSize"]);
		public static int DefaultTimeoutSeconds => int.Parse(ConfigurationManager.AppSettings["DefaultTimeoutSeconds"]);
		public static string OutputPath => ConfigurationManager.AppSettings["OutputDirectory"];
		public static DirectoryInfo OutputDirectory => new DirectoryInfo(OutputPath);

		public static Encoding GetEncodingType(string value)
		{
			try
			{
				return Encoding.GetEncoding(value);
			}
			catch (Exception e)
			{
				Console.WriteLine($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static string GetDbfConnectionString(FileInfo file)
		{
			try
			{
				string filePath = file.DirectoryName;

				if (string.IsNullOrWhiteSpace(filePath))
					throw new ArgumentNullException(
						"The specified directory is invalid. Please check the file path and directory and try again!", nameof(filePath));

				if (!filePath.EndsWith("\\"))
					filePath += "\\";

				if (filePath.Contains(" "))
					filePath = $"\"{filePath}\"";

				return string.Format(DbfConnectionStringTemplate, filePath);

				//return string.Format(DbfConnectionStringTemplate, GetShortFilePath(file));
			}
			catch (Exception e)
			{
				Console.WriteLine($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static string GetDbfSelectString(FileInfo file)
		{
			try
			{
				return $"SELECT * FROM [{file.Name}]";
				//return $"SELECT * FROM [{file.Name.Replace(file.Extension, "")}]";
			}
			catch (Exception e)
			{
				Console.WriteLine($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static DataTable CreateDataTable<T>(IEnumerable<T> entities)
		{
			try
			{
				Type t = typeof (T);

				PropertyInfo[] properties = t.GetProperties().Where(EventTypeFilter).ToArray();
				DataTable table = new DataTable();

				foreach (PropertyInfo property in properties)
				{
					Type propertyType = property.PropertyType;

					if (propertyType.IsGenericType
					    &&
					    propertyType.GetGenericTypeDefinition() == typeof (Nullable<>))
					{
						propertyType = Nullable.GetUnderlyingType(propertyType);
					}

					table.Columns.Add(new DataColumn(property.Name, propertyType));
				}

				foreach (T entity in entities)
				{
					table.Rows.Add(properties.Select(
						property => GetPropertyValue(
							property.GetValue(entity, null))).ToArray());
				}

				return table;
			}
			catch (Exception e)
			{
				Console.WriteLine($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		private static bool EventTypeFilter(PropertyInfo p)
		{
			NotMappedAttribute notMappedAttribute = Attribute.GetCustomAttribute(p,
				typeof (NotMappedAttribute)) as NotMappedAttribute;

			if (notMappedAttribute != null)
				return false;

			AssociationAttribute associationAttribute = Attribute.GetCustomAttribute(p,
				typeof (AssociationAttribute)) as AssociationAttribute;

			if (associationAttribute == null)
				return true;
			return associationAttribute.IsForeignKey == false;
		}

		private static object GetPropertyValue(object o)
		{
			return o ?? DBNull.Value;
		}

		public static void SqlBulkCopy_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
		{
			if (!(sender is SqlBulkCopy sbc))
			{
				e.Abort = true;
				return;
			}

			Console.Write(
				$"\r{e.RowsCopied} Rows Copied to the '{sbc.DestinationTableName}' table | Abort: {e.Abort} | Streaming: {sbc.EnableStreaming}\t\t\t\t\t\t");
		}

		public static bool IsInUse(this FileInfo file)
		{
			try
			{
				using (
					FileStream fs = new FileStream(file.FullName,
						FileMode.Open,
						FileSystemRights.ReadAndExecute,
						FileShare.None,
						4096,
						FileOptions.Asynchronous))
				{
					fs.FlushAsync();
					fs.Close();
				}
			}
			catch (IOException ioe)
			{
#if DEBUG
				Debug.WriteLine($"{ioe.Message}\r\n{ioe}");
#endif
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.Message}\r\n{e}");
				throw;
			}

			//file is not locked
			return false;
		}

		public static FileInfo CreateWorkingFile(FileInfo file)
		{
			try
			{
				ImportFileType fileType = ESRIHelper.GetImportFileType(file);
				string fileExtension = ESRIHelper.GetImportFileExtension(fileType);
				string tempName = Path.GetRandomFileName().Split('.')[0];
				tempName = tempName.Length > 8 ? tempName.Substring(0, 8) : tempName;
				string tableName = $"{tempName}{fileExtension}";
				string workingFilePath = Path.Combine(EXEHelper.WorkingPath, tableName);

				FileInfo workingFile = file.CopyTo(workingFilePath, true);
				return workingFile;
			}
			catch (Exception e)
			{
				Console.WriteLine($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static string GetShortFilePath(FileInfo file)
		{
			StringBuilder output = new StringBuilder(255);

			int n = GetShortPathName(file.FullName, output, 255);

			if (n == 0)
				throw new Exception(Marshal.GetLastWin32Error().ToString());

			return output.ToString().Replace(file.Name, "");
		}

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern int GetShortPathName(string path, StringBuilder shortPath, int shortPathLength);

		public static void FillDataSetFromDbf(FileInfo file, ref DataSet data)
		{
			try
			{
				string connectionString = GetDbfConnectionString(file);
				string selectString = GetDbfSelectString(file);
				using (OleDbConnection conn = new OleDbConnection(connectionString))
				using ( OleDbCommand cmd = conn.CreateCommand())
				{
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = selectString;
					cmd.CommandTimeout = DefaultTimeoutSeconds;

					cmd.Connection.Open();

					OleDbDataAdapter da = new OleDbDataAdapter(cmd);
					da.FillSchema(data, SchemaType.Source);
					da.Fill(data);

					cmd.Connection.Close();
					conn.Close();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}

		public static string StripCommas(this string source)
		{
			return source.Replace(",", "");
		}

		public static int? ToNullableInt(this string source)
		{
			int i;
			return int.TryParse(source.StripCommas(), out i) ? i : (int?) null;
		}

		public static long? ToNullableLong(this string source)
		{
			long i;
			return long.TryParse(source.StripCommas(), out i) ? i : (long?) null;
		}

		public static decimal? ToNullableDecimal(this string source)
		{
			decimal i;
			return decimal.TryParse(source.StripCommas(), out i) ? i : (decimal?) null;
		}
	}
}