namespace GISParser.Models.Binding
{
	#region Library Imports

	using System;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.IO;
	using System.Text;

	#endregion

	public class CodePageFile : ImportFile
	{
		public CodePageFile()
		{
		}

		public CodePageFile(FileInfo file)
			: base(file)
		{
			ImportFromFile(file);
		}

		public string EncodingValue { get; set; }

		[NotMapped]
		public Encoding Encoding => Encoding.GetEncoding(EncodingValue ?? "UTF8");

		public void ImportFromFile(FileInfo file)
		{
			try
			{
				using (StreamReader sr = new StreamReader(file.OpenRead()))
				{
					EncodingValue = sr.ReadToEnd();
					Console.WriteLine($"\r{file.Name.Split('.')[0]} has an encoding type of {EncodingValue}\t\t\t\t\t");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}
	}
}