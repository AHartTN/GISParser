namespace GISParser
{
	#region Library Imports

	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Data;
	using System.Data.Entity.Design.PluralizationServices;
	using System.Data.Entity.Spatial;
	using System.Data.SqlClient;
	using System.Diagnostics;
	using System.Globalization;
	using System.IO;
	using System.IO.Compression;
	using System.Linq;
	using System.Threading.Tasks;
	using Helpers;
	using Microsoft.SqlServer.Types;
	using Microsoft.VisualBasic.FileIO;
	using Models.Base;
	using Models.Binding;
	using SearchOption = System.IO.SearchOption;

	#endregion

	public class GISParser
	{
		public PluralizationService Pluralizer = PluralizationService.CreateService(CultureInfo.CurrentCulture);

		/// <summary>
		///     The directory path to the folder that contains the folder structure of the MAF/Tiger Data
		/// </summary>
		public string SourceDirectoryPath => ConfigurationManager.AppSettings["SourceDirectory"];

		/// <summary>
		///     The directory path to the folder that files will be output to
		/// </summary>
		public string OutputDirectoryPath => ConfigurationManager.AppSettings["OutputDirectory"];

		/// <summary>
		///     The directory path to the folder that the metadata files will be extracted to
		/// </summary>
		public string MetadataDirectoryPath => Path.Combine(OutputDirectoryPath, "Metadata");

		/// <summary>
		///     The directory path where all the generated files go
		/// </summary>
		public string GeneratedDirectoryPath => Path.Combine(OutputDirectoryPath, "Generated");

		/// <summary>
		///     The directory that contains the folder structure of the MAF/Tiger Data
		/// </summary>
		public DirectoryInfo SourceDirectory => new DirectoryInfo(SourceDirectoryPath);

		/// <summary>
		///     The directory that files will be output to
		/// </summary>
		public DirectoryInfo OutputDirectory => new DirectoryInfo(OutputDirectoryPath);

		/// <summary>
		///     The directory that the metadata files will be extracted to
		/// </summary>
		public DirectoryInfo MetadataDirectory => new DirectoryInfo(MetadataDirectoryPath);

		/// <summary>
		///     The directory where all of the generated files go
		/// </summary>
		public DirectoryInfo GeneratedDirectory => new DirectoryInfo(GeneratedDirectoryPath);

		/// <summary>
		///     The directories contained within the source directory that contain the actual zip files
		/// </summary>
		public IEnumerable<DirectoryInfo> Directories => SourceDirectory.EnumerateDirectories();

		/// <summary>
		///     The total number of directories that will be parsed
		/// </summary>
		public long DirectoryCount => Directories.Count();

		/// <summary>
		///     A dictionary object containing a complete list of all directories and their containing files
		/// </summary>
		public Dictionary<DirectoryInfo, IEnumerable<FileInfo>> DirectoryFiles
			=> Directories.ToDictionary(k => k, v => v.EnumerateFiles("*.*", SearchOption.AllDirectories));

		/// <summary>
		///     The total number of zip files that will be parsed
		/// </summary>
		public long ZipFileCount => DirectoryFiles.Sum(s => s.Value.Count());

		public void ProcessData()
		{
			if (string.IsNullOrWhiteSpace(SourceDirectoryPath))
				throw new ArgumentException(
					"The specified directory does not exist or is otherwise invalid. Check the directory in the configuration file and try again.",
					nameof(SourceDirectoryPath));

			if (!(DirectoryCount > 0))
				throw new ArgumentException(
					"The specified directory contains no directories for processing. Check the directory contents and try again.",
					nameof(SourceDirectory));

			if (!(ZipFileCount > 0))
				throw new ArgumentException(
					"The specified directory contains no files within the directory structure for processing. Check the directory contents and try again.");

			Console.WriteLine(
				$"\rBeginning parse of {SourceDirectory.Name} | {DirectoryCount} Directories containing {ZipFileCount} Zip Files will be processed.\t\t\t\t");

			#region File Processing

			// Single-Threaded Operation
			foreach (KeyValuePair<DirectoryInfo, IEnumerable<FileInfo>> directory in DirectoryFiles.OrderBy(o => o.Value.Count()).ThenByDescending(t => t.Key.Name))
			{
				ProcessDirectory(directory);
			}

			// Multi-Threaded Operation
			//Parallel.ForEach(DirectoryFiles, ProcessDirectory);

			#endregion File Processing
		}

		public void ProcessDirectory(KeyValuePair<DirectoryInfo, IEnumerable<FileInfo>> directory)
		{
			if (!directory.Key.Exists)
				throw new ArgumentException("The directory specified does not exist. Unable to process directory.",
					nameof(directory.Key));

			if (directory.Value == null || !directory.Value.Any())
				throw new ArgumentException("The specified directory contains no files to parse. Unable to process directory",
					nameof(directory.Value));

			NameDefinitionType nameDefinitionType =
				(NameDefinitionType)Enum.Parse(typeof(NameDefinitionType), directory.Key.Name);
			string nameDefinition = Dictionaries.NameDefinitions[nameDefinitionType];

			//TODO: TEMPORARY! REMOVE THIS TO PREVENT SKIPPING!
			//if (nameDefinitionType == NameDefinitionType.ADDR)
			//	return;

			Console.WriteLine(
				$"Now processing {directory.Value.Count()} zip files in the {nameDefinitionType} ({nameDefinition}) directory");

			RawGISDataEntities db = new RawGISDataEntities();
			db.Database.Initialize(true);

			// Single-Threaded Operation
			foreach (FileInfo file in directory.Value)
			{
				ProcessZipFile(nameDefinitionType, file);
			}

			// Multi-Threaded Operation
			//Parallel.ForEach(directory.Value, value => ProcessZipFile(nameDefinitionType, value));
		}

		public void ProcessZipFile(NameDefinitionType nameDefinitionType, FileInfo file)
		{
			#region File Path Strings

			string fileName = file.Name.Replace(file.Extension, "");
			string outputPath = Path.Combine(OutputDirectoryPath, fileName);
			string codePageFilePath = Path.Combine(outputPath, $"{fileName}.cpg");
			string projectionFilePath = Path.Combine(outputPath, $"{fileName}.prj");
			//string dbfMetadataFilePath = Path.Combine(outputPath, $"{fileName}.dbf.xml");
			//string shpMetadataFilePath = Path.Combine(outputPath, $"{fileName}.shp.xml");
			string attributeFilePath = Path.Combine(outputPath, $"{fileName}.dbf");
			string shapeFilePath = Path.Combine(outputPath, $"{fileName}.shp");

			#endregion File Path Strings

			#region File Infos

			FileInfo codePageFileInfo = new FileInfo(codePageFilePath);
			FileInfo projectionFileInfo = new FileInfo(projectionFilePath);
			//FileInfo dbfMetadataFileInfo = new FileInfo(dbfMetadataFilePath);
			//FileInfo shpMetadataFileInfo = new FileInfo(shpMetadataFilePath);
			FileInfo attributeFileInfo = new FileInfo(attributeFilePath);
			FileInfo shapeFileInfo = new FileInfo(shapeFilePath);

			#endregion File Infos

			#region Directory Prep

			if (Directory.Exists(outputPath))
			{
				Console.WriteLine($"Deleting Directory: {outputPath}");
				FileSystem.DeleteDirectory(outputPath, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
			}

			#endregion Directory Prep

			#region File Extraction

			Console.WriteLine($"\rExtracting {file.Name} to {outputPath}\t\t");
			ZipFile.ExtractToDirectory(file.FullName, outputPath);

			#endregion File Extration

			#region File Prep

			Console.WriteLine("Removing XML Files");

			foreach (string isoFile in Directory.EnumerateFiles(outputPath, "*.xml"))
				FileSystem.DeleteFile(isoFile, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);

			if (attributeFileInfo.Exists && attributeFileInfo.Name.Length > 8)
			{
				Console.WriteLine("Renaming Attribute File");
				string newName = "Attrib.dbf";
				FileSystem.RenameFile(attributeFilePath, newName);

				attributeFilePath = Path.Combine(outputPath, newName);
				attributeFileInfo = new FileInfo(attributeFilePath);
			}

			#endregion File Prep

			#region File Processing

			Console.WriteLine("Processing files");
			CodePageFile codePageFile = new CodePageFile(codePageFileInfo);
			ProjectionFile projectionFile = new ProjectionFile(projectionFileInfo);



			//MetadataFile dbfMetadataFile = new MetadataFile(dbfMetadataFileInfo);
			//MetadataFile shpMetadataFile = new MetadataFile(shpMetadataFileInfo);
			//MetadataFile metadataFile = new MetadataFile(dbfMetadataFileInfo.Exists ? dbfMetadataFileInfo : shpMetadataFileInfo);

			//if (dbfMetadataFile.Exists && shpMetadataFile.Exists)
			//{
			//	Console.WriteLine($"{fileName} has both shape and attribute metadata files!");
			//	Debugger.Break();
			//}

			AttributeFile attributeFile = new AttributeFile(attributeFileInfo);
			ShapeFile shapeFile = projectionFile.Exists ? new ShapeFile(shapeFileInfo, projectionFile.SRID) : null;

			#endregion

			if (shapeFile != null)
			{
				DataColumn newColumn = new DataColumn("GEOM", typeof(SqlGeometry));
				attributeFile.Records.Tables[0].Columns.Add(newColumn);

				foreach (Shape shape in shapeFile.Shapes)
				{
					attributeFile.Records.Tables[0].Rows[shape.RecordNumber - 1][newColumn.ColumnName] = shape.DTGeometry;
				}
			}

			using (SqlBulkCopy sbc = new SqlBulkCopy(DataHelper.DefaultConnectionString))
			{
				sbc.SqlRowsCopied += Sbc_SqlRowsCopied;
				sbc.DestinationTableName = Pluralizer.Pluralize(nameDefinitionType.ToString());
				sbc.BatchSize = DataHelper.DefaultBatchSize;
				sbc.BulkCopyTimeout = DataHelper.DefaultTimeoutSeconds;

				foreach (DataColumn column in attributeFile.Records.Tables[0].Columns)
					sbc.ColumnMappings.Add(column.ColumnName, column.ColumnName);

				sbc.WriteToServer(attributeFile.Records.Tables[0]);
			}

			#region Directory Cleanup

			Console.WriteLine($"Deleting Directory: {outputPath}");
			FileSystem.DeleteDirectory(outputPath, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);

			#endregion Directory Cleanup
		}

		private void Sbc_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
		{
			Console.WriteLine($"SQL Bulk Copy: {e.RowsCopied} Rows Copied | Abort: {e.Abort}");
		}
	}
}