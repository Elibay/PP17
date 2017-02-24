using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
namespace Snake
{
	class MainClass
	{
		public static int d = 0;
		public static void Main(string[] args)
		{
			Console.SetCursorPosition(10, 10);
			Console.WriteLine("Welcome\n        -----> SNAKE <----");
			Game game = new Game();
			Thread thread = new Thread(game.Move);
			thread.Start();
			while (true)
			{
				game.snake.Move();
			}
		}
	}
}
