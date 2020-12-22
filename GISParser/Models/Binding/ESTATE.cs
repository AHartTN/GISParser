using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class ESTATE : BaseModel
{
	public short? STATEFP { get; set; }
	public short? COUNTYFP { get; set; }
	public int? ESTATEFP { get; set; }
	public int? ESTATENS { get; set; }
	public long GEOID { get; set; }
	[MaxLength(36, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string NAME { get; set; }
	[MaxLength(43, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string NAMELSAD { get; set; }
	public short? LSAD { get; set; }
	[MaxLength(2, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string CLASSFP { get; set; }
	[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string MTFCC { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string FUNCSTAT { get; set; }
	public int? ALAND { get; set; }
	public int? AWATER { get; set; }
	public float INTPTLAT { get; set; }
	public float INTPTLON { get; set; }
	public DbGeometry GEOM { get; set; }
}