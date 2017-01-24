using System;

namespace Program
{
	class Cls
	{
		static int gcd(int x, int y)
		{
			if (x == 0)
				return y;
			return gcd(y % x, x);
		}
		public int a, b;
		public Cls(int a, int b)
		{
			this.a = a;
			this.b = b;
		}
		// rewrite function ToString 
		public override string ToString()
		{
			return a + "/" + b;
		}
		// rewrtite operator +
		public static Cls operator +(Cls a, Cls b)
		{
			Cls p = new Cls(a.a * b.b + a.b * b.a, a.b * b.b);
			int z = gcd(p.a, p.b);
			p.a = p.a / z;
			p.b = p.b / z;
			return p;
		}
	}
	class MainClass
	{
		public static void Main(string[] args)
		{
			Cls a = new Cls(1, 2);
			Cls b = new Cls(1, 3);
			Cls c = a + b + b;
			Console.WriteLine(c);
			Console.ReadKey();
		}
	}
}