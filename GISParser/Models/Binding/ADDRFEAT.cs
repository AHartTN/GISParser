namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.ComponentModel.DataAnnotations;
	using System.Data.Entity.Spatial;
	using Base;
	using Microsoft.SqlServer.Types;

	#endregion

	public class ADDRFEAT : BaseModel
	{
		public int? TLID { get; set; }
		public int? TFIDL { get; set; }
		public int? TFIDR { get; set; }
		public long? ARIDL { get; set; }
		public long? ARIDR { get; set; }
		public long? LINEARID { get; set; }

		[MaxLength(57, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string FULLNAME { get; set; }

		[MaxLength(12, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string LFROMHN { get; set; }

		[MaxLength(12, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string LTOHN { get; set; }

		[MaxLength(12, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string RFROMHN { get; set; }

		[MaxLength(12, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string RTOHN { get; set; }

		public int? ZIPL { get; set; }
		public int? ZIPR { get; set; }

		[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string EDGE_MTFCC { get; set; }

		[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string ROAD_MTFCC { get; set; }

		public string PARITYL { get; set; }
		public string PARITYR { get; set; }
		public string PLUS4L { get; set; }
		public string PLUS4R { get; set; }
		public string LFROMTYP { get; set; }
		public string LTOTYP { get; set; }
		public string RFROMTYP { get; set; }
		public string RTOTYP { get; set; }
		public string OFFSETL { get; set; }
		public string OFFSETR { get; set; }
		public DbGeometry GEOM { get; set; }
	}
}