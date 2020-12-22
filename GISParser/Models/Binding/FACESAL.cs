using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class FACESAL : BaseModel
{
	public int? TFID { get; set; }
	public long AREAID { get; set; }
	public DbGeometry GEOM { get; set; }
}