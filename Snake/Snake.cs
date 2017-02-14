using System;
using System.IO;
using System.Collections.Generic;

namespace Snake
{
	public class Snake
	{
		public List <Point> body;
		public char sign = '*';
		public ConsoleColor color;
		public int GM;
		public int[,] u = new int[50, 50];
		public Snake()
		{
			body = new List<Point>();
			body.Add(new Point(10, 10));
			color = ConsoleColor.Yellow;
		}
		public void Move(int dx, int dy)
		{
			for (int i = 0; i < 50; ++i)
				for (int j = 0; j < 50; ++j)
					u[i, j] = 0;
			for (int i = body.Count - 1; i > 0; --i)
			{
				body[i].x = body[i - 1].x;
				body[i].y = body[i - 1].y;
				u[body[i].x, body[i].y] = 1;
			}
			body[0].x += dx;
			body[0].y += dy;
			if (u[body[0].x, body[0].y] == 1)
				GM = 1;
			if (body[0].x >= 19 || body[0].x < 1 || body[0].y >= 19 || body[0].y < 1)
				GM = 1;
			u[body[0].x, body[0].y] = 1;
		}
		public void Draw()
		{
			Console.ForegroundColor = color;
			foreach (Point p in body)
			{
				Console.SetCursorPosition(p.x, p.y);
				Console.Write(sign);
			}
		}
	}
}
