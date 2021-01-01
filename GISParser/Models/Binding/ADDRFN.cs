using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class ADDRFN : BaseModel
{
	public long? ARID { get; set; }
	public long? LINEARID { get; set; }
	public DbGeography GEOG { get; set; }
}