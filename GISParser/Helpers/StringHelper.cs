namespace GISParser.Helpers
{
	#region Library Imports

	using System;

	#endregion

	public static class StringHelper
	{
		public static string GetProgressString(long charIndex, long fileLength, string name)
		{
			try
			{
				decimal rawValue = (decimal) charIndex/fileLength;
				string percentage = rawValue.ToString("P4");
				return $"\r{DateTime.Now} | {charIndex} of {fileLength} ({percentage}): {name}\t\t";
			}
			catch (Exception e)
			{
				Console.WriteLine($"\r\n{e.Message}\r\n{e}");
				throw;
			}
		}
	}
}