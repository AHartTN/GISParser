namespace GISParser
{
	#region Library Imports

	using System;

	#endregion

	public class Program
	{
		private static void Main(string[] args)
		{
			Initialize();

			GISParser parser = new GISParser();
			parser.ProcessData();

			Console.WriteLine("END OF APPLICATION | PRESS ENTER TO EXIT!");
			Console.ReadLine();
		}

		private static void Initialize()
		{
			Console.BufferHeight = short.MaxValue - 1;
			Console.BufferWidth = 1024;
		}
	}
}