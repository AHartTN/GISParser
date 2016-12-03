namespace GISParser.Models.Binding
{
	#region Library Imports

	using System.Data.Entity;

	#endregion

	public class RawGISDataEntities : DbContext
	{
		public RawGISDataEntities() : base("DefaultConnection")
		{
		}

		public RawGISDataEntities(string connectionName) : base(connectionName)
		{
		}

		public DbSet<ADDR> ADDRs { get; set; }
		public DbSet<ADDRFEAT> ADDRFEATs { get; set; }
		public DbSet<ADDRFN> ADDRFNs { get; set; }
		public DbSet<AIANNH> AIANNHs { get; set; }
		public DbSet<AITSN> AITSNs { get; set; }
		public DbSet<ANRC> ANRCs { get; set; }
		public DbSet<AREALM> AREALMs { get; set; }
		public DbSet<AREAWATER> AREAWATERs { get; set; }
		public DbSet<BG> BGs { get; set; }
		public DbSet<CBSA> CBSAs { get; set; }
		public DbSet<CD> CDs { get; set; }
		public DbSet<CNECTA> CNECTAs { get; set; }
		public DbSet<COASTLINE> COASTLINEs { get; set; }
		public DbSet<CONCITY> CONCITies { get; set; }
		public DbSet<COUNTY> COUNTies { get; set; }
		public DbSet<COUSUB> COUSUBs { get; set; }
		public DbSet<CSA> CSAs { get; set; }
		public DbSet<EDGES> EDGES { get; set; }
		public DbSet<ELSD> ELSDs { get; set; }
		public DbSet<ESTATE> ESTATEs { get; set; }
		public DbSet<FACES> FACES { get; set; }
		public DbSet<FACESAH> FACESAHs { get; set; }
		public DbSet<FACESAL> FACESALs { get; set; }
		public DbSet<FACESMIL> FACESMILs { get; set; }
		public DbSet<FEATNAMES> FEATNAMES { get; set; }
		public DbSet<LINEARWATER> LINEARWATERs { get; set; }
		public DbSet<METDIV> METDIVs { get; set; }
		public DbSet<MIL> MILs { get; set; }
		public DbSet<NECTA> NECTAs { get; set; }
		public DbSet<NECTADIV> NECTADIVs { get; set; }
		public DbSet<PLACE> PLACEs { get; set; }
		public DbSet<POINTLM> POINTLMs { get; set; }
		public DbSet<PRIMARYROADS> PRIMARYROADS { get; set; }
		public DbSet<PRISECROADS> PRISECROADS { get; set; }
		public DbSet<PUMA> PUMAs { get; set; }
		public DbSet<RAILS> RAILS { get; set; }
		public DbSet<ROADS> ROADS { get; set; }
		public DbSet<SCSD> SCSDs { get; set; }
		public DbSet<SLDL> SLDLs { get; set; }
		public DbSet<SLDU> SLDUs { get; set; }
		public DbSet<STATE> STATEs { get; set; }
		public DbSet<SUBBARRIO> SUBBARRIOs { get; set; }
		public DbSet<SUBMCD> SUBMCDs { get; set; }
		public DbSet<TABBLOCK> TABBLOCKs { get; set; }
		public DbSet<TBG> TBGs { get; set; }
		public DbSet<TRACT> TRACTs { get; set; }
		public DbSet<TTRACT> TTRACTs { get; set; }
		public DbSet<UAC> UACs { get; set; }
		public DbSet<UNSD> UNSDs { get; set; }
		public DbSet<ZCTA5> ZCTA5 { get; set; }
	}
}