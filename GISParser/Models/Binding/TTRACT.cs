using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class TTRACT : BaseModel
{
	public short? AIANNHCE { get; set; }
	[MaxLength(6, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string TTRACTCE { get; set; }
	[MaxLength(10, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string GEOID { get; set; }
	[MaxLength(4, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string NAME { get; set; }
	[MaxLength(24, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string NAMELSAD { get; set; }
	[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string MTFCC { get; set; }
	public long? ALAND { get; set; }
	public int? AWATER { get; set; }
	public float INTPTLAT { get; set; }
	public float INTPTLON { get; set; }
	public DbGeography GEOG { get; set; }
}