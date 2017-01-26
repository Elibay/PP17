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
		static void Get(string path)
		{
			Console.WriteLine("gg");
			int[] lvl = new int [10000];
			string[] a = new string[1000];

			int l = 0, r = 1;
			lvl[0] = 0;
			a[0] = path;
			while (l < r)
			{
				++ l;
				if (lvl[l] > 3)
					continue;
				DirectoryInfo directory = new DirectoryInfo(a[l - 1]);
				FileInfo[] files = directory.GetFiles();
				DirectoryInfo[] directories = directory.GetDirectories();
				foreach (FileInfo file in files)
				{
					emptySpace(lvl[l - 1]);
					Console.WriteLine(file.Name);
				}
				foreach (DirectoryInfo dInfo in directories)
				{
					emptySpace(lvl[l - 1]);
					Console.WriteLine(dInfo.Name);
					if (r <= 1000)
					{
						a[r] = (dInfo.FullName);
						lvl[r] = lvl[l - 1] + 1;
						++r;
					}
				}
			}
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
			Get(@"/Users/elibay/Projects");
			//Rec (@"/Users/elibay/Projects", 0);
		}
	}
}