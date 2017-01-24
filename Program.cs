using System;
using System.IO;
namespace Student
{
	class MainClass
	{
		static void MaxMin()
		{
			StreamReader sr = new StreamReader(@"/Users/elibay/Documents/input.txt");
			string[] arr = sr.ReadLine().Split();
			int x = 9999, y = 0;
			foreach (string s in arr)
			{
				int p = int.Parse(s);
				if (p < x)
					x = p;
				if (p > y)
					y = p;
			}
			Console.WriteLine(x + " " + y);
			sr.Close();
		}
		static void Main(string[] args)
		{
			MaxMin();
		}
	}
}