namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.ComponentModel.DataAnnotations;
	using System.Data.Entity.Spatial;
	using Base;
	using Microsoft.SqlServer.Types;

	#endregion

	public class TBG : BaseModel
	{
		public short? AIANNHCE { get; set; }

		[MaxLength(6, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string TTRACTCE { get; set; }

		public string TBLKGPCE { get; set; }

		[MaxLength(11, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string GEOID { get; set; }

		[MaxLength(20, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string NAMELSAD { get; set; }

		[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string MTFCC { get; set; }

		public long? ALAND { get; set; }
		public int? AWATER { get; set; }
		public float INTPTLAT { get; set; }
		public float INTPTLON { get; set; }
		public DbGeometry GEOM { get; set; }
	}
}