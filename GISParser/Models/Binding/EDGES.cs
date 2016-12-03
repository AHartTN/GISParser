namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.ComponentModel.DataAnnotations;
	using System.Data.Entity.Spatial;
	using Base;
	using Microsoft.SqlServer.Types;

	#endregion

	public class EDGES : BaseModel
	{
		public short? STATEFP { get; set; }
		public short? COUNTYFP { get; set; }
		public int? TLID { get; set; }
		public int? TFIDL { get; set; }
		public int? TFIDR { get; set; }

		[MaxLength(5, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string MTFCC { get; set; }

		[MaxLength(61, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string FULLNAME { get; set; }

		public short? SMID { get; set; }

		[MaxLength(12, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string LFROMADD { get; set; }

		[MaxLength(12, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string LTOADD { get; set; }

		[MaxLength(12, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string RFROMADD { get; set; }

		[MaxLength(12, ErrorMessage = "{0}'s length must be {1} characters or less")]
		public string RTOADD { get; set; }

		public int? ZIPL { get; set; }
		public int? ZIPR { get; set; }
		public string FEATCAT { get; set; }
		public string HYDROFLG { get; set; }
		public string RAILFLG { get; set; }
		public string ROADFLG { get; set; }
		public string OLFFLG { get; set; }
		public string PASSFLG { get; set; }
		public string DIVROAD { get; set; }
		public string EXTTYP { get; set; }
		public string TTYP { get; set; }
		public string DECKEDROAD { get; set; }
		public string ARTPATH { get; set; }
		public string PERSIST { get; set; }
		public string GCSEFLG { get; set; }
		public string OFFSETL { get; set; }
		public string OFFSETR { get; set; }
		public int? TNIDF { get; set; }
		public int? TNIDT { get; set; }
		public DbGeometry GEOM { get; set; }
	}
}