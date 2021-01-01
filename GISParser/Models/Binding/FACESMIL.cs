using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class FACESMIL : BaseModel
{
	public int? TFID { get; set; }
	public long? AREAID { get; set; }
	public DbGeography GEOG { get; set; }
}