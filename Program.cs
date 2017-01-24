using System;
using System.IO;
namespace Student
{
	class MainClass
	{
		static void emptySpace(int level)
		{
			for (int i = 0; i < level; ++i)
				Console.Write("-");
			Console.Write("> ");
		}
		static void Rec(string path, int level)
		{
			if (level > 3)
				return;
			DirectoryInfo directory = new DirectoryInfo(path);
			FileInfo[] files = directory.GetFiles();
			DirectoryInfo[] directories = directory.GetDirectories();
			foreach (FileInfo file in files)
			{
				emptySpace(level);
				Console.WriteLine(file.Name);
			}
			foreach (DirectoryInfo dInfo in directories)
			{
				emptySpace(level);
				Console.WriteLine(dInfo.Name);
				Rec (dInfo.FullName, level + 1);
			}
		}
		static void Main(string[] args)
		{
			Rec (@"/Users/elibay/Projects", 0);
		}
	}
}