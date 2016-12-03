namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.ComponentModel.DataAnnotations;
	using Base;

	#endregion

	public class ADDR : BaseModel
	{
		public int? TLID { get; set; }

		[MaxLength(12, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string FROMHN { get; set; }

		[MaxLength(12, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string TOHN { get; set; }

		public string SIDE { get; set; }
		public int? ZIP { get; set; }
		public string PLUS4 { get; set; }
		public string FROMTYP { get; set; }
		public string TOTYP { get; set; }
		public long? ARID { get; set; }

		[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string MTFCC { get; set; }
	}
}