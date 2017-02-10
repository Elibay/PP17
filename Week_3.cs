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
		static void ShowInfo(DirectoryInfo directory, int cursor)
		{
			Console.BackgroundColor = ConsoleColor.Black;
			int index = 0;
			foreach (FileSystemInfo fInfo in directory.GetFileSystemInfos())
			{
				if (index == cursor)
					Console.ForegroundColor = ConsoleColor.Red;
				else
					Console.ForegroundColor = ConsoleColor.Green;
				index++;
				if (fInfo.GetType() == typeof(FileInfo))
					Console.Write("File: ");
				else
					Console.Write("Directory: ");
				Console.WriteLine(fInfo.Name);
			}
		}
		static void ShowFile(FileSystemInfo fInfo, int cursor)
		{
			Console.Clear();
			String line = System.IO.File.ReadAllText(fInfo.FullName);
			Console.WriteLine(line);
			while (true)
			{
				ConsoleKeyInfo pressedKey = Console.ReadKey();
				if (pressedKey.Key == ConsoleKey.Escape)
					return;
			}
		}
		static void Answer (DirectoryInfo directory, int x)
		{
			int cursor = x;
			while (true)
			{
				Console.Clear();
				ShowInfo(directory, cursor);
				ConsoleKeyInfo pressedKey = Console.ReadKey();
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