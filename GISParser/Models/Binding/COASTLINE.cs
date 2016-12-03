namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.ComponentModel.DataAnnotations;
	using System.Data.Entity.Spatial;
	using Base;
	using Microsoft.SqlServer.Types;

	#endregion

	public class COASTLINE : BaseModel
	{
		[MaxLength(11, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string NAME { get; set; }

		[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string MTFCC { get; set; }

		public DbGeometry GEOM { get; set; }
	}
}