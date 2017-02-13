using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace Snake
{
	class Snake
	{
		public List<Point> body;
		public char sign = '*';
		public ConsoleColor color;
		public Snake()
		{
			body = new List<Point>();
			body.Add(new Point(10, 10));
			color = ConsoleColor.Yellow;
		}
		public void Move(int dx, int dy)
		{
			for (int i = body.Count - 1; i > 0; --i)
			{
				body[i].x = body[i - 1].x;
				body[i].y = body[i - 1].y;
			}
			body[0].x += dx;
			body[0].y += dy;
			if (body[0].x >= 19 || body[0].x < 1 || body[0].y >= 19 || body[0].y < 1)
			{
				Console.Clear();
				Console.SetCursorPosition(10, 10);
				Console.WriteLine("GAME OVER");
				Environment.Exit(0);
			}
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
	class MainClass
	{
		public static void Main(string[] args)
		{
			Wall wall = new Wall();
			Snake snake = new Snake();
			Food food = new Food();
			while (true)
			{
				ConsoleKeyInfo pressed = Console.ReadKey();
				if (pressed.Key == ConsoleKey.UpArrow)
					snake.Move(0, -1);
				if (pressed.Key == ConsoleKey.DownArrow)
					snake.Move(0, 1);
				if (pressed.Key == ConsoleKey.RightArrow)
					snake.Move(1, 0);
				if (pressed.Key == ConsoleKey.LeftArrow)
					snake.Move(-1, 0);
				if (pressed.Key == ConsoleKey.Escape)
					break;
				if (food.x == snake.body[0].x && food.y == snake.body[0].y)
				{
					snake.body.Add(new Point(0, 0));
					food = new Food();
				}
				Console.Clear();
				wall.Draw();
				snake.Draw();
				food.Draw();
			}

		}
	}
}
