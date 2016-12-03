namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.ComponentModel.DataAnnotations;
	using Base;

	#endregion

	public class FEATNAMES : BaseModel
	{
		public int? TLID { get; set; }

		[MaxLength(61, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string FULLNAME { get; set; }

		[MaxLength(61, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string NAME { get; set; }

		[MaxLength(2, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string PREDIRABRV { get; set; }

		[MaxLength(14, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string PRETYPABRV { get; set; }

		[MaxLength(3, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string PREQUALABR { get; set; }

		[MaxLength(2, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string SUFDIRABRV { get; set; }

		[MaxLength(14, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string SUFTYPABRV { get; set; }

		[MaxLength(3, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string SUFQUALABR { get; set; }

		public short? PREDIR { get; set; }
		public short? PRETYP { get; set; }
		public short? PREQUAL { get; set; }
		public short? SUFDIR { get; set; }
		public short? SUFTYP { get; set; }
		public short? SUFQUAL { get; set; }
		public long? LINEARID { get; set; }

		[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string MTFCC { get; set; }

		public string PAFLAG { get; set; }
	}
}