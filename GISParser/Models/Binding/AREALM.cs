using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class AREALM : BaseModel
{
	public short? STATEFP { get; set; }
	public int? ANSICODE { get; set; }
	public long? AREAID { get; set; }
	[MaxLength(93, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string FULLNAME { get; set; }
	[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string MTFCC { get; set; }
	public long? ALAND { get; set; }
	public long? AWATER { get; set; }
	public float INTPTLAT { get; set; }
	public float INTPTLON { get; set; }
	public string PARTFLG { get; set; }
	public DbGeography GEOG { get; set; }
}