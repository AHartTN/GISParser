using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class ELSD : BaseModel
{
	public short? STATEFP { get; set; }
	public int? ELSDLEA { get; set; }
	public int? GEOID { get; set; }
	[MaxLength(61, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string NAME { get; set; }
	public short? LSAD { get; set; }
	[MaxLength(2, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string LOGRADE { get; set; }
	public short? HIGRADE { get; set; }
	[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string MTFCC { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string SDTYP { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string FUNCSTAT { get; set; }
	public long ALAND { get; set; }
	public long AWATER { get; set; }
	public float INTPTLAT { get; set; }
	public float INTPTLON { get; set; }
	public DbGeometry GEOM { get; set; }
}