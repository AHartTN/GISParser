using System.Data.Entity.Spatial;
using GISParser.Models.Base;

public class FACESAH : BaseModel
{
	public int? TFID { get; set; }
	public long? HYDROID { get; set; }
	public DbGeography GEOG { get; set; }
}