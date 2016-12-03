namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.ComponentModel.DataAnnotations;
	using System.Data.Entity.Spatial;
	using Base;
	using Microsoft.SqlServer.Types;

	#endregion

	public class COUNTY : BaseModel
	{
		public short? STATEFP { get; set; }
		public short? COUNTYFP { get; set; }
		public int? COUNTYNS { get; set; }
		public int? GEOID { get; set; }

		[MaxLength(21, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string NAME { get; set; }

		[MaxLength(33, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string NAMELSAD { get; set; }

		public short? LSAD { get; set; }

		[MaxLength(2, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string CLASSFP { get; set; }

		[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string MTFCC { get; set; }

		public short? CSAFP { get; set; }
		public int? CBSAFP { get; set; }
		public int? METDIVFP { get; set; }
		public string FUNCSTAT { get; set; }
		public long? ALAND { get; set; }
		public long? AWATER { get; set; }
		public float INTPTLAT { get; set; }
		public float INTPTLON { get; set; }
		public DbGeometry GEOM { get; set; }
	}
}