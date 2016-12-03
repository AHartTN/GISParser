namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.IO;
	using Base;
	using Enumerators;

	#endregion

	#region Imports

	#endregion

	public class ImportFile : BaseFile
	{
		public ImportFile()
		{
		}

		public ImportFile(FileInfo file)
			: base(file)
		{
		}

		public ShapeType ShapeType { get; set; }

		public int? FileCode { get; set; }

		public int? ContentLength { get; set; }

		public int? FileVersion { get; set; }
	}
}