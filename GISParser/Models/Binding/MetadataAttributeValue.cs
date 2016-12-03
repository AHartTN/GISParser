namespace GISParser.Models.Binding
{
	public class MetadataAttributeValue
	{
		public string Udom { get; set; }
		public string CodeSetName { get; set; }
		public string CodeSetSource { get; set; }
		public decimal? MinRange { get; set; }
		public decimal? MaxRange { get; set; }
		public string Value { get; set; }
		public string Definition { get; set; }
		public string Source { get; set; }
	}
}