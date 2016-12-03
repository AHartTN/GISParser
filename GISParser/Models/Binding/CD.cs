namespace GISParser.Models.Binding
{
	using System.ComponentModel.DataAnnotations;
	using System.Data.Entity.Spatial;
	using Base;

	#region Library Imports
	

	#endregion

	public class CD : BaseModel
	{
		public short? STATEFP { get; set; }

		[MaxLength(2, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string CD115FP { get; set; }

		[MaxLength(4, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string GEOID { get; set; }

		[MaxLength(41, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string NAMELSAD { get; set; }

		[MaxLength(2, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string LSAD { get; set; }

		public short? CDSESSN { get; set; }

		[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string MTFCC { get; set; }

		public string FUNCSTAT { get; set; }
		public long? ALAND { get; set; }
		public long? AWATER { get; set; }
		public float INTPTLAT { get; set; }
		public float INTPTLON { get; set; }
		public DbGeometry GEOM { get; set; }
	}
}