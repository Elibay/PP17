using System;
namespace Snake
{
	public class Food : Fucntions
	{
		public Point NFood(Snake snake, Wall wall)
		{
			Random rnd = new Random(DateTime.Now.Millisecond);
			int mod = 19;
			int x = rnd.Next(mod);
			int y = rnd.Next(mod);
			int b = 1;
			while (b == 1)
			{
				x = rnd.Next(mod);
				y = rnd.Next(mod);
				b = 0;
				for (int i = wall.body.Count - 1; i >= 0; --i)
					if (x == wall.body[i].x && y == wall.body[i].y)
						b = 1;
				for (int i = snake.body.Count - 1; i >= 0; --i)
					if (x == snake.body[i].x && y == snake.body[i].y)
						b = 1;
			}
			return new Point(x, y);
		}
		public Food(Snake snake, Wall wall, int cnt)
		{
			sign = '+';
			color = ConsoleColor.Green;
			body = new System.Collections.Generic.List<Point>();
			for (int i = 1; i <= cnt; ++ i)
				body.Add(NFood(snake, wall));
		}
	}
}
