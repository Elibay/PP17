using System;
using System.IO;
namespace Student
{
	class MainClass
	{
		static bool check(int x)
		{
			if (x == 1)
				return false;
			for (int i = 2; i * i <= x; ++i)
				if (x % i == 0)
					return false;
			return true;
		}
		static void MaxMin()
		{
			StreamReader sr = new StreamReader(@"/Users/elibay/Documents/input.txt");
			StreamWriter sw = new StreamWriter(@"/Users/elibay/Documents/output.txt");
			string[] arr = sr.ReadLine().Split();
			int x = 999999;
			foreach (string s in arr)
			{
				int p = int.Parse(s);
				if (p < x && check (p))
					x = p;
			}
			sw.WriteLine(x);
			sw.Close();
			sr.Close();
		}
		static void Main(string[] args)
		{
			MaxMin();
		}
	}
}