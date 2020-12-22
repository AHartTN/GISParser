using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class SLDL : BaseModel
{	public short? STATEFP { get; set; }
	[MaxLength(3, ErrorMessage="{0}'s length must be {1} characters or less")]
	public string SLDLST { get; set; }
	[MaxLength(5, ErrorMessage="{0}'s length must be {1} characters or less")]
	public string GEOID { get; set; }
	[MaxLength(47, ErrorMessage="{0}'s length must be {1} characters or less")]
	public string NAMELSAD { get; set; }
	[MaxLength(2, ErrorMessage="{0}'s length must be {1} characters or less")]
	public string LSAD { get; set; }
	public short? LSY { get; set; }
	[MaxLength(5, ErrorMessage="{0}'s length must be {1} characters or less")]
	public string MTFCC { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string FUNCSTAT { get; set; }
	public long ALAND { get; set; }
	public long AWATER { get; set; }
	public float INTPTLAT { get; set; }
	public float INTPTLON { get; set; }
	public DbGeometry GEOM { get; set; }
}