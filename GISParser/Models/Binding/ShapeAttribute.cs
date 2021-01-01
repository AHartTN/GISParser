namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.ComponentModel.DataAnnotations.Schema;

	#endregion

	[Table("ShapeAttribute")]
	public class ShapeAttribute
	{
		public long? Id { get; set; }

		public long? AttributeFileId { get; set; }

		public int? RecordNumber { get; set; }

		public string Name { get; set; }

		public string Value { get; set; }

		public AttributeFile AttributeFile { get; set; }
	}
}