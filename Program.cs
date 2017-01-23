
using System;

namespace Application
{
	class MainClass
	{
		// Function check we must check number is prime or not
		static bool check(int x)
		{
			if (x == 1)
				return false;
			for (int i = 2; i * i <= x; ++i)
				if (x % i == 0)
					return false;
			return true;
		}
		public static void Main(string[] args)
		{
			int n = args.Length;
			for (int i = 0; i < n; ++i)
			{
				// Convert to int
				int p = int.Parse(args[i]);
				if (check(p))
					// Print this number
					Console.WriteLine(p);
			}
		}
	}
}