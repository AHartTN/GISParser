namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.ComponentModel.DataAnnotations;
	using System.Data.Entity.Spatial;
	using Base;
	using Microsoft.SqlServer.Types;

	#endregion

	public class POINTLM : BaseModel
	{
		public short? STATEFP { get; set; }
		public int? ANSICODE { get; set; }
		public long? POINTID { get; set; }

		[MaxLength(81, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string FULLNAME { get; set; }

		[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string MTFCC { get; set; }

		public DbGeometry GEOM { get; set; }
	}
}