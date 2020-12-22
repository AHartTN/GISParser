using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class TABBLOCK : BaseModel
{	public short? STATEFP10 { get; set; }
	public short? COUNTYFP10 { get; set; }
	public int? TRACTCE10 { get; set; }
	public short? BLOCKCE10 { get; set; }
	public long GEOID10 { get; set; }
	[MaxLength(10, ErrorMessage="{0}'s length must be {1} characters or less")]
	public string NAME10 { get; set; }
	[MaxLength(5, ErrorMessage="{0}'s length must be {1} characters or less")]
	public string MTFCC10 { get; set; }
	[MaxLength(1, ErrorMessage="{0}'s length must be {1} characters or less")]
	public string UR10 { get; set; }
	public int? UACE10 { get; set; }
	[MaxLength(1, ErrorMessage="{0}'s length must be {1} characters or less")]
	public string UATYPE { get; set; }
	[MaxLength(1, ErrorMessage="{0}'s length must be {1} characters or less")]
	public string FUNCSTAT10 { get; set; }
	public long ALAND10 { get; set; }
	public long AWATER10 { get; set; }
	public float INTPTLAT10 { get; set; }
	public float INTPTLON10 { get; set; }
	public DbGeometry GEOM { get; set; }
}