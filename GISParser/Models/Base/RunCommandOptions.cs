namespace GISParser.Models.Base
{
	#region Library Imports

	using System.Diagnostics;

	#endregion

	public class RunCommandOptions
	{
		public RunCommandOptions()
		{
			CreateNoWindow = false;
			UseShellExecute = false;
			RedirectStandardError = true;
			RedirectStandardInput = false;
			RedirectStandardOutput = true;
			WindowStyle = ProcessWindowStyle.Hidden;
		}

		public bool CreateNoWindow { get; set; }
		public bool UseShellExecute { get; set; }
		public bool RedirectStandardError { get; set; }
		public bool RedirectStandardInput { get; set; }
		public bool RedirectStandardOutput { get; set; }
		public ProcessWindowStyle WindowStyle { get; set; }

		public static RunCommandOptions GetDefaults()
		{
			return new RunCommandOptions();
		}
	}
}