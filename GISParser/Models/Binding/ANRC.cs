using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class ANRC : BaseModel
{
	public short? STATEFP { get; set; }
	public int? ANRCFP { get; set; }
	public int? ANRCNS { get; set; }
	public int? GEOID { get; set; }
	[MaxLength(14, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string NAME { get; set; }
	[MaxLength(49, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string NAMELSAD { get; set; }
	public short? LSAD { get; set; }
	[MaxLength(2, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string CLASSFP { get; set; }
	[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string MTFCC { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string FUNCSTAT { get; set; }
	public long ALAND { get; set; }
	public long AWATER { get; set; }
	public float INTPTLAT { get; set; }
	public float INTPTLON { get; set; }
	public DbGeometry GEOM { get; set; }
}