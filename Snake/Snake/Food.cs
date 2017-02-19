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
			while (snake.u[x, y] == 1 || wall.u[x, y] == 1 || u[x, y] == 1)
			{
				x = rnd.Next(mod);
				y = rnd.Next(mod);
			}
			u[x, y] = 1;
			return new Point(x, y);
		}
		public Food(Snake snake, Wall wall, int cnt)
		{
			for (int i = 0; i < 50; ++i)
				for (int j = 0; j < 50; ++j)
					u[i, j] = 0;
			sign = '+';
			color = ConsoleColor.Green;
			body = new System.Collections.Generic.List<Point>();
			for (int i = 1; i <= cnt; ++ i)
				body.Add(NFood(snake, wall));
		}
	}
}
