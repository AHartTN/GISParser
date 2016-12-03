namespace GISParser.Models.Base
{
	#region Library Imports

	using System;
	using System.Collections.Generic;

	#endregion

	public class TableColumn
	{
		public TableColumn()
		{
			Tables = new HashSet<NameDefinitionType>();
			Sources = new HashSet<string>();
			Definitions = new HashSet<string>();
			CodeSets = new HashSet<Tuple<string, string>>();
			Udoms = new HashSet<string>();
			Values = new HashSet<ColumnValue>();
		}

		public Type DataType { get; set; }
		public string Name { get; set; }
		public decimal? MinRange { get; set; }
		public decimal? MaxRange { get; set; }

		public ICollection<NameDefinitionType> Tables { get; set; }
		public ICollection<string> Sources { get; set; }
		public ICollection<string> Definitions { get; set; }
		public ICollection<Tuple<string, string>> CodeSets { get; set; }
		public ICollection<string> Udoms { get; set; }
		public ICollection<ColumnValue> Values { get; set; }
	}

	public class ColumnValue
	{
		public ColumnValue()
		{
			Sources = new HashSet<string>();
			Definitions = new HashSet<string>();
		}

		public string Value { get; set; }
		public ICollection<string> Sources { get; set; }
		public ICollection<string> Definitions { get; set; }
	}
}