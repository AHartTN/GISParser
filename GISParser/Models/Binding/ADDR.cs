using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class ADDR : BaseModel
{
	public int? TLID { get; set; }
	[MaxLength(12, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string FROMHN { get; set; }
	[MaxLength(12, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string TOHN { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string SIDE { get; set; }
	public int? ZIP { get; set; }
	public short? PLUS4 { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string FROMTYP { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string TOTYP { get; set; }
	public long? ARID { get; set; }
	[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string MTFCC { get; set; }
	public DbGeography GEOG { get; set; }
}