using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace Snake
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Wall wall = new Wall();
			Snake snake = new Snake();
			Food food = new Food();
			while (snake.u[food.x, food.y] == 1)
				food = new Food();
			int cnt = 1;
			int Max = 1;
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
					while (snake.u[food.x, food.y] == 1)
						food = new Food();
					++cnt;
				}
				if (Max < cnt)
					Max = cnt;
				if (snake.GM == 1)
				{
					Console.Clear();
					Console.SetCursorPosition(10, 5);
					Console.WriteLine("GAME OVER");

					Console.SetCursorPosition(10, 6);
					Console.Write("Your score: ");
					Console.WriteLine(cnt);
					Console.SetCursorPosition(10, 7);
					Console.Write("Max score: ");
					Console.WriteLine(Max);
					Console.SetCursorPosition(10, 8);
					Console.WriteLine ("Repeate?");
					Console.SetCursorPosition(10, 9);
					Console.WriteLine("Y || N");
					while (true)
					{
						ConsoleKeyInfo p = Console.ReadKey();
						if (p.Key == ConsoleKey.Y)
							break;
						if (p.Key == ConsoleKey.N)
							Environment.Exit(0);
					}
					snake = new Snake ();
					food = new Food();
					while (snake.u[food.x, food.y] == 1)
						food = new Food();
					cnt = 1;
				}
				Console.Clear();
				wall.Draw();
				snake.Draw();
				food.Draw();
				Console.SetCursorPosition(40, 10);
				Console.Write("Curent score: ");
				Console.WriteLine(cnt);
				Console.SetCursorPosition(40, 11);
				Console.Write("Max score: ");
				Console.WriteLine(Max);
				Console.SetCursorPosition (50, 20);
			}
		}
	}
}
