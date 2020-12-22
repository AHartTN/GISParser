using GISParser.Models.Base;

namespace GISParser.Models.Binding
{
	public class Point : BaseModel
	{
		public int? SortIndex { get; set; }

		public double X { get; set; }

		public double Y { get; set; }

		public double? Z { get; set; }

		public double? M { get; set; }

		public string Coordinates => $"{X} {Y} {Z} {M}".Trim().Replace("  ", " ");
	}
}