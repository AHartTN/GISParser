namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.Collections.Generic;

	#endregion

	public class MetadataAttribute
	{
		public MetadataAttribute()
		{
			Values = new HashSet<MetadataAttributeValue>();
		}

		public string ColumnName { get; set; }
		public string Definition { get; set; }
		public string Source { get; set; }
		public ICollection<MetadataAttributeValue> Values { get; set; }
	}
}