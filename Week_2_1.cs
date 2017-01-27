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
			int[] lvl = new int [10000], w = new int [10000];
			string[] a = new string[1000];

			int sz = 1;
			lvl[1] = 0;
			a[1] = path;
			while (sz > 0)
			{
				if (lvl[sz] > 3)
				{
					sz--;
					continue;
				}
				DirectoryInfo directory = new DirectoryInfo(a[sz]);
				DirectoryInfo[] directories = directory.GetDirectories();
				int b = 0;
				for (int i = w[sz]; i < directories.Length; i++)
				{
					DirectoryInfo dInfo = directories[i];
					emptySpace(lvl[sz]);
					Console.WriteLine(dInfo.Name);
					sz++;
					a[sz] = dInfo.FullName;
					lvl[sz] = lvl[sz - 1] + 1;
					w[sz - 1] = i + 1;
					b = 1;
					break;
				}
				if (b == 0)
				{
					for (int i = sz; i <= 100; ++i)
						w[i] = 0;
					sz--;

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