using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class POINTLM : BaseModel
{
	public short? STATEFP { get; set; }
	public int? ANSICODE { get; set; }
	public long POINTID { get; set; }
	[MaxLength(79, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string FULLNAME { get; set; }
	[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string MTFCC { get; set; }
	public DbGeometry GEOM { get; set; }
}