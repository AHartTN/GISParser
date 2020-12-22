namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.ComponentModel.DataAnnotations.Schema;
	using Base;

	#endregion

	[Table("ShapeIndex")]
	public class ShapeIndex : BaseModel
	{
		public long IndexFileId { get; set; }

		public int? RecordNumber { get; set; }

		public int? Offset { get; set; }

		public int? ContentLength { get; set; }

		public IndexFile IndexFile { get; set; }
	}
}