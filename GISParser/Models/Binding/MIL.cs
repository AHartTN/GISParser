namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.ComponentModel.DataAnnotations;
	using System.Data.Entity.Spatial;
	using Base;
	using Microsoft.SqlServer.Types;

	#endregion

	public class MIL : BaseModel
	{
		public int? ANSICODE { get; set; }
		public long? AREAID { get; set; }

		[MaxLength(83, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string FULLNAME { get; set; }

		[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string MTFCC { get; set; }

		public long? ALAND { get; set; }
		public int? AWATER { get; set; }
		public float INTPTLAT { get; set; }
		public float INTPTLON { get; set; }
		public DbGeometry GEOM { get; set; }
	}
}