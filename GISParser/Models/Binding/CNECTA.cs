using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class CNECTA : BaseModel
{	public short? CNECTAFP { get; set; }
	public short? GEOID { get; set; }
	[MaxLength(43, ErrorMessage="{0}'s length must be {1} characters or less")]
	public string NAME { get; set; }
	[MaxLength(58, ErrorMessage="{0}'s length must be {1} characters or less")]
	public string NAMELSAD { get; set; }
	[MaxLength(2, ErrorMessage="{0}'s length must be {1} characters or less")]
	public string LSAD { get; set; }
	[MaxLength(5, ErrorMessage="{0}'s length must be {1} characters or less")]
	public string MTFCC { get; set; }
	public long? ALAND { get; set; }
	public long? AWATER { get; set; }
	public float INTPTLAT { get; set; }
	public float INTPTLON { get; set; }
	public DbGeography GEOG { get; set; }
}