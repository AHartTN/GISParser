namespace GISParser
{
	#region Library Imports

	using System.Collections.Generic;

	#endregion

	public class Dictionaries
	{
		#region Name Definitions

		public static Dictionary<NameDefinitionType, string> NameDefinitions = new Dictionary<NameDefinitionType, string>
		{
			{NameDefinitionType.ADDR, "Address Range Relationship File"},
			{NameDefinitionType.ADDRFEAT, "Address Range Feature"},
			{NameDefinitionType.ADDRFN, "Address Range-Feature Name Relationship"},
			{NameDefinitionType.AIANNH, "American Indian / Alaska Native / Native Hawaiian Areas"},
			{NameDefinitionType.AITSN, "American Indian Tribal Subdivision National"},
			{NameDefinitionType.ANRC, "Alaska Native Regional Corporation"},
			{NameDefinitionType.AREALM, "Area Landmark"},
			{NameDefinitionType.AREAWATER, "Area Hydrography"},
			{NameDefinitionType.BG, "Block Group"},
			{NameDefinitionType.CBSA, "Metropolitan Statistical Area / Micropolitan Statistical Area"},
			{NameDefinitionType.CD, "Congressional District"},
			{NameDefinitionType.CNECTA, "Combined New England City and Town Area"},
			{NameDefinitionType.COASTLINE, "Coastline"},
			{NameDefinitionType.CONCITY, "Consolidated City"},
			{NameDefinitionType.COUNTY, "County"},
			{NameDefinitionType.COUSUB, "County Subdivision"},
			{NameDefinitionType.CSA, "Combined Statistical Area"},
			{NameDefinitionType.EDGES, "All Lines"},
			{NameDefinitionType.ELSD, "Elementary School District"},
			{NameDefinitionType.ESTATE, "Estate"},
			{NameDefinitionType.FACES, "Topological Faces (Polygons with All Geocodes)"},
			{NameDefinitionType.FACESAH, "Topological Faces-Area Hydrography Relationship File"},
			{NameDefinitionType.FACESAL, "Topological Faces-Area Landmark Relationship File"},
			{NameDefinitionType.FACESMIL, "Topological Faces-Military Installation Relationship File"},
			{NameDefinitionType.FEATNAMES, "Feature Names Relationship File"},
			{NameDefinitionType.LINEARWATER, "Linear Hydrography"},
			{NameDefinitionType.METDIV, "Metropolitan Division"},
			{NameDefinitionType.MIL, "Military Installation"},
			{NameDefinitionType.NECTA, "New England City and Town Area"},
			{NameDefinitionType.NECTADIV, "New England City and Town Area Division"},
			{NameDefinitionType.PLACE, "Place"},
			{NameDefinitionType.POINTLM, "Point Landmark"},
			{NameDefinitionType.PRIMARYROADS, "Primary Roads"},
			{NameDefinitionType.PRISECROADS, "Primary and Secondary Roads"},
			{NameDefinitionType.PUMA, "Public Use Microdata Area"},
			{NameDefinitionType.RAILS, "Rails"},
			{NameDefinitionType.ROADS, "All Roads"},
			{NameDefinitionType.SCSD, "Secondary School Districts"},
			{NameDefinitionType.SLDL, "State Legislative District – Lower Chamber"},
			{NameDefinitionType.SLDU, "State Legislative District – Upper Chamber"},
			{NameDefinitionType.STATE, "State and Equivalent"},
			{NameDefinitionType.SUBBARRIO, "SubMinor Civil Division (Subbarios in Puerto Rico)"},
			{NameDefinitionType.SUBMCD, "SubMinor Civil Division (Subbarios in Puerto Rico)"},
			{NameDefinitionType.TABBLOCK, "Tabulation (Census) Block"},
			{NameDefinitionType.TBG, "Tribal Block Group"},
			{NameDefinitionType.TRACT, "Census Tract"},
			{NameDefinitionType.TTRACT, "Tribal Census Tract"},
			{NameDefinitionType.UAC, "Urban Area/Urban Cluster"},
			{NameDefinitionType.UNSD, "Unified School District"},
			{NameDefinitionType.ZCTA5, "5-Digit ZIP Code Tabulation Area"}
		};

		#endregion Name Definitions
	}
}