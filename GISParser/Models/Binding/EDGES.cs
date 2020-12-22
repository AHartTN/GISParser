using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using GISParser.Models.Base;

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
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string FEATCAT { get; set; }
	public bool HYDROFLG { get; set; }
	public bool RAILFLG { get; set; }
	public bool ROADFLG { get; set; }
	public bool OLFFLG { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string PASSFLG { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string EXTTYP { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string TTYP { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string DECKEDROAD { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string ARTPATH { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string PERSIST { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string GCSEFLG { get; set; }
	public bool OFFSETL { get; set; }
	public bool OFFSETR { get; set; }
	public int? TNIDF { get; set; }
	public int? TNIDT { get; set; }
	public DbGeometry GEOM { get; set; }
}