using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using GISParser.Models.Base;

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
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string PARITYL { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string PARITYR { get; set; }
	public short? PLUS4L { get; set; }
	public short? PLUS4R { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string LFROMTYP { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string LTOTYP { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string RFROMTYP { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string RTOTYP { get; set; }
	public string OFFSETL { get; set; }
	public string OFFSETR { get; set; }
	public DbGeography GEOG { get; set; }
}