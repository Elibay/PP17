using System;
namespace Snake
{
	public class Food
	{
		public int x, y;
		public char sign = '+';
		public Food()
		{
			Random rnd = new Random(DateTime.Now.Millisecond);
			int mod = 19;
			x = rnd.Next(mod);
			y = rnd.Next(mod);
			while (x == 0 || x == 19)
			{
				x = rnd.Next(mod);
			}
			while (y == 0 || y == 19)
			{
				y = rnd.Next(mod);
			}
		}
		public void Draw()
		{
			Console.SetCursorPosition(x, y);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(sign);
		}
	}
}
