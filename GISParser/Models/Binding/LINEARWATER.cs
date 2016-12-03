namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.ComponentModel.DataAnnotations;
	using System.Data.Entity.Spatial;
	using Base;
	using Microsoft.SqlServer.Types;

	#endregion

	public class LINEARWATER : BaseModel
	{
		public string ANSICODE { get; set; }
		public long? LINEARID { get; set; }

		[MaxLength(55, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string FULLNAME { get; set; }

		public string ARTPATH { get; set; }

		[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string MTFCC { get; set; }

		public DbGeometry GEOM { get; set; }
	}
}