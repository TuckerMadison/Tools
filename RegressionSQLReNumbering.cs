//This takes a txt file and then will renumber it to fit into a regression suite
//I use this for when I am copying steps from one test to another, or when having to repete a step multiple times.
//This is ran in visual studios, I didnt like running it through the command prompt.
//The 'start' variable on line 21 needs to be changed everytime. I use to take this through args, but did not like it as much.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RegressionSQLReNumbering
{
	class Program
	{
		static void Main( string[] args )
		{
			LinkedList<string> toWrite = new LinkedList<string>();
			//Change int start to match where the last step was created
			//int start = Int32.Parse( args[1] );
			int start = 70;
			int lineNumber = -1;
			using( StreamReader reader = File.OpenText( @"FILE" ) )
				while( !reader.EndOfStream )
				{
					string line = reader.ReadLine();
					lineNumber = lineNumber + 1;
					//if( null == line )
						//continue;
					start = start + 5;
					string newLine = reNumber( line, start );
					toWrite.AddLast( newLine.Trim() );
				}
			//string[] output = toWrite.ToArray();
			System.IO.File.WriteAllLines( @"FILE", toWrite );
		}

		public static string reNumber( string input, int startAt )
		{
			int firstTab = input.IndexOf( '\t' );
			int secondTab = input.IndexOf( '\t', firstTab + 1 );
			String toReplace = input.Substring( firstTab + 1, secondTab - firstTab );

			String theString = input.Replace( toReplace, startAt.ToString() + '\t' );

			return theString.Trim();
		}
	}
}
