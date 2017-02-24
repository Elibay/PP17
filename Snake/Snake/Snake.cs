using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
	public class Snake : Fucntions
	{
		public int GM;
		int[] dx = new int[]{0, 0, -1, 1};
		int[] dy = new int[]{1, -1, 0, 0};
		public int d = 0;
		public Snake()
		{
			sign = '*';
			body = new List<Point>();
			body.Add(new Point(10, 10));
			color = ConsoleColor.Yellow;
		}
		public void Move()
		{
			ConsoleKeyInfo pressed = Console.ReadKey();
			if (pressed.Key == ConsoleKey.UpArrow)
				MainClass.d = 1;
			if (pressed.Key == ConsoleKey.DownArrow)
				MainClass.d = 0;
			if (pressed.Key == ConsoleKey.RightArrow)
				MainClass.d = 3;
			if (pressed.Key == ConsoleKey.LeftArrow)
				MainClass.d = 2;
			//Move2();
		}
		public void Move2(int d)
		{
			Erase();
			for (int i = body.Count - 1; i > 0; --i)
			{
				body[i].x = body[i - 1].x;
				body[i].y = body[i - 1].y;
			}
			body[0].x += dx[d];
			body[0].y += dy[d];
			if (body[0].x >= 20)
				body[0].x = 0;
			if (body[0].y >= 20)
				body[0].y = 0;
			if (body[0].x < 0)
				body[0].x = 19;
			if (body[0].y < 0)
				body[0].y = 19;
			for (int i = body.Count - 1; i > 0; --i)
				if (body[i].x == body[0].x && body[i].y == body[0].y)
					GM = 1;
		}
		public void Game_Over(Wall wall)
		{
			for (int i = wall.body.Count - 1; i >= 0; --i)
				if (wall.body[i].x == body[0].x && wall.body[i].y == body[0].y)
					GM = 1;
		}
	}
}
