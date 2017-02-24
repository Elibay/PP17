using System;
using System.Threading;
using System.Threading.Tasks;
namespace Snake
{
	public class Game
	{
		public Snake snake;
		public Wall wall;
		public Food food;
		public static void Game_Over(int cnt, int Max)
		{
			Console.Clear();
			Console.SetCursorPosition(10, 5);
			Console.WriteLine("GAME OVER");
			Console.SetCursorPosition(10, 6);
			Console.WriteLine("Your score: " + cnt);
			Console.SetCursorPosition(10, 7);
			Console.WriteLine("Max score: " + Max);
			Console.SetCursorPosition(10, 8);
			Console.WriteLine("Repeate?");
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
		}
		public Game()
		{
			wall = new Wall("lvl1.txt");
			snake = new Snake();
			food = new Food(snake, wall, 1);
		}
		int cnt = 1, cnt2 = 1, Max = 1, lvl = 1, Cl = 1;
		public void Move()
		{
			while (true)
			{
				snake.Move2(MainClass.d);
				snake.Game_Over(wall);
				food.Erase();
				if (snake.GM == 1)
				{
					Console.Clear();
					Game_Over(cnt, Max);
					snake = new Snake();
					food = new Food(snake, wall, 1);
					cnt = 1; cnt2 = 1; Cl = 1;
				}
				else if (food.body[0].x == snake.body[0].x && food.body[0].y == snake.body[0].y)
				{
					snake.body.Add(new Point(food.body[0].x, food.body[0].y));
					food = new Food(snake, wall, 1);
					++cnt; ++cnt2;
				}
				if (Max < cnt)
					Max = cnt;
				if (cnt2 % 10 == 0 && cnt2 <= 40)
				{
					if (lvl == 1)
						wall = new Wall("lvl2.txt");
					else if (lvl == 2)
						wall = new Wall("lvl3.txt");
					lvl++;
					if (lvl < 4)
					{
						snake = new Snake();
						food = new Food(snake, wall, 1);
					}
					cnt2 = 1;
					Cl = 1;
				}
				// -> Print Snake
				if (Cl == 1)
				{
					Console.Clear();
					wall.Draw();
					Cl = 0;
				}
				snake.Draw();
				food.Draw();
				Console.SetCursorPosition(40, 10);
				Console.Write("Curent score: ");
				Console.WriteLine(cnt);
				Console.SetCursorPosition(40, 11);
				Console.Write("Max score: ");
				Console.WriteLine(Max);
				Console.SetCursorPosition(50, 20);
				// <- 
				Thread.Sleep(300);
			}	
		}
	}
}
