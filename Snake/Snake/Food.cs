using System;
using System.IO;
namespace Snake
{
	public class Food : Fucntions
	{
		public Food()
		{
			Random rnd = new Random(DateTime.Now.Millisecond);
			int mod = 19;
			int x = rnd.Next(mod);
			int y = rnd.Next(mod);
			sign = '+';
			color = ConsoleColor.Green;
			body = new System.Collections.Generic.List<Point>();
			body.Add(new Point (x, y));
		}
	}
}
