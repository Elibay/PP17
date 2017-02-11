using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Example2
{
	class Program
	{
		// Main Show function 
		static void ShowInfo(DirectoryInfo directory, int cursor)
		{
			Console.BackgroundColor = ConsoleColor.Black; // changing Background color 
			int index = 0;
			// Print all files and folders
			foreach (FileSystemInfo fInfo in directory.GetFileSystemInfos())
			{
				if (index == cursor)
					Console.ForegroundColor = ConsoleColor.Red;
				else
					Console.ForegroundColor = ConsoleColor.Green;
				index ++;
				if (fInfo.GetType() == typeof(FileInfo))
					Console.Write("File: ");
				else
					Console.Write("Directory: ");
				Console.WriteLine(fInfo.Name);
			}
		}
		// File show function
		static void ShowFile(FileSystemInfo fInfo, int cursor)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Gray;
			String line = System.IO.File.ReadAllText(fInfo.FullName);
			Console.WriteLine(line);
			// until you press the Escape
			while (true)
			{
				ConsoleKeyInfo pressedKey = Console.ReadKey();
				if (pressedKey.Key == ConsoleKey.Escape)
				{
					Console.Clear();
					return;
				}
			}
		}
		// Main Program 
		static void Answer (DirectoryInfo directory, int x)
		{
			int cursor = x;
			// until you press the Escape
			while (true)
			{
				Console.Clear();
				// Showing what we have in our directory
				ShowInfo(directory, cursor);
				ConsoleKeyInfo pressedKey = Console.ReadKey();
				// changing Cursor
				if (pressedKey.Key == ConsoleKey.UpArrow)
				{
					if (cursor > 0)
						cursor--;
					else
						cursor = directory.GetFileSystemInfos().Length - 1;
				}
				if (pressedKey.Key == ConsoleKey.DownArrow)
				{
					if (cursor < directory.GetFileSystemInfos().Length - 1)
						cursor++;
					else
						cursor = 0;
				}
				// if Enter we must change directory or open file
				if (pressedKey.Key == ConsoleKey.Enter)
				{
					FileSystemInfo fi = directory.GetFileSystemInfos()[cursor];
					if (fi.GetType() == typeof(FileInfo))
					{
						ShowFile(fi, cursor);
					}
					else
						Answer(new DirectoryInfo(fi.FullName), 0);
				}
				// if Backspace we must change directory and back
				if (pressedKey.Key == ConsoleKey.Backspace)
				{
					return;
				}
				if (pressedKey.Key == ConsoleKey.Escape)
					Environment.Exit(0);
			}
		}
		static void Main(string[] args)
		{
			Answer(new DirectoryInfo(@"/Users/elibay/Projects"), 0);
		}
	}
}