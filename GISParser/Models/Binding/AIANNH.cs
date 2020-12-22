using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class AIANNH : BaseModel
{
	public short? AIANNHCE { get; set; }
	public int? AIANNHNS { get; set; }
	[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string GEOID { get; set; }
	[MaxLength(59, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string NAME { get; set; }
	[MaxLength(74, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string NAMELSAD { get; set; }
	[MaxLength(2, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string LSAD { get; set; }
	[MaxLength(2, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string CLASSFP { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string COMPTYP { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string AIANNHR { get; set; }
	[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string MTFCC { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string FUNCSTAT { get; set; }
	public long ALAND { get; set; }
	public int? AWATER { get; set; }
	public float INTPTLAT { get; set; }
	public float INTPTLON { get; set; }
	public DbGeometry GEOM { get; set; }
}