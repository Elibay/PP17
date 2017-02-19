using System;
using System.Collections.Generic;
namespace Snake
{
	public class Fucntions
	{
		public int[,] u = new int[50, 50];
		public List<Point> body;
		public char sign;
		public ConsoleColor color;
		public void Draw()
		{
			Console.ForegroundColor = color;
			foreach (Point p in body)
			{
				Console.SetCursorPosition(p.x, p.y);
				Console.Write(sign);
			}
			Console.CursorVisible = false;
		}
		public void Erase()
		{
			foreach (Point p in body)
			{
				Console.SetCursorPosition(p.x, p.y);
				Console.Write(' ');
			}
			Console.CursorVisible = false;
		}
	}
}
