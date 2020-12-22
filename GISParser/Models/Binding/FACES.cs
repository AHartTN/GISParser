using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class FACES : BaseModel
{
	public int? TFID { get; set; }
	public short? STATEFP10 { get; set; }
	public short? COUNTYFP10 { get; set; }
	public int? TRACTCE10 { get; set; }
	public short? BLKGRPCE10 { get; set; }
	public short? BLOCKCE10 { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string SUFFIX1CE { get; set; }
	public int? ZCTA5CE10 { get; set; }
	public int? UACE10 { get; set; }
	public int? PUMACE10 { get; set; }
	public short? STATEFP { get; set; }
	public short? COUNTYFP { get; set; }
	public int? TRACTCE { get; set; }
	public short? BLKGRPCE { get; set; }
	public int? COUSUBFP { get; set; }
	public int? SUBMCDFP { get; set; }
	public int? ESTATEFP { get; set; }
	public int? CONCTYFP { get; set; }
	public int? PLACEFP { get; set; }
	public int? AIANNHFP { get; set; }
	public short? AIANNHCE { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string COMPTYP { get; set; }
	public int? TRSUBFP { get; set; }
	public short? TRSUBCE { get; set; }
	public int? ANRCFP { get; set; }
	[MaxLength(6, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string TTRACTCE { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string TBLKGPCE { get; set; }
	public int? ELSDLEA { get; set; }
	public int? SCSDLEA { get; set; }
	public int? UNSDLEA { get; set; }
	[MaxLength(2, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string CD116FP { get; set; }
	[MaxLength(3, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string SLDUST { get; set; }
	[MaxLength(3, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string SLDLST { get; set; }
	public short? CSAFP { get; set; }
	public int? CBSAFP { get; set; }
	public int? METDIVFP { get; set; }
	public short? CNECTAFP { get; set; }
	public int? NECTAFP { get; set; }
	public int? NCTADVFP { get; set; }
	[MaxLength(1, ErrorMessage = "{0}'s length must be {1} characters or less")]
	public string LWFLAG { get; set; }
	public bool OFFSET { get; set; }
	public long ATOTAL { get; set; }
	public float INTPTLAT { get; set; }
	public float INTPTLON { get; set; }
	public DbGeometry GEOM { get; set; }
}