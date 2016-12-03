namespace GISParser.Models.Binding
{
	using System.ComponentModel.DataAnnotations;
	using System.Data.Entity.Spatial;
	using Base;

	public class CBSA : BaseModel
	{
		public short? CSAFP { get; set; }
		public int? CBSAFP { get; set; }
		public int? GEOID { get; set; }

		[MaxLength(46, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string NAME { get; set; }

		[MaxLength(57, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string NAMELSAD { get; set; }

		[MaxLength(2, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string LSAD { get; set; }

		public short? MEMI { get; set; }

		[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string MTFCC { get; set; }

		public long? ALAND { get; set; }
		public long? AWATER { get; set; }
		public float INTPTLAT { get; set; }
		public float INTPTLON { get; set; }
		public DbGeometry GEOM { get; set; }
	}
}