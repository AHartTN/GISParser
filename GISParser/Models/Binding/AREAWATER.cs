namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.ComponentModel.DataAnnotations;
	using System.Data.Entity.Spatial;
	using Base;
	using Microsoft.SqlServer.Types;

	#endregion

	public class AREAWATER : BaseModel
	{
		public string ANSICODE { get; set; }
		public long? HYDROID { get; set; }

		[MaxLength(48, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string FULLNAME { get; set; }

		[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string MTFCC { get; set; }

		public int? ALAND { get; set; }
		public long? AWATER { get; set; }
		public float INTPTLAT { get; set; }
		public float INTPTLON { get; set; }
		public DbGeometry GEOM { get; set; }
	}
}