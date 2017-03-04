using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace Snake2
{
	class MainClass
	{
		public static int d = 1;
		public static int speed = 1;
		public static void Main(string[] args)
		{
			Console.SetCursorPosition(10, 10);
			Console.WriteLine("Welcome");
			Console.SetCursorPosition(10, 11);
			Console.WriteLine("Chose your speed");
			Console.SetCursorPosition(10, 12);
			Console.WriteLine("A B C D");
			ConsoleKeyInfo sp = Console.ReadKey();
			if (sp.Key == ConsoleKey.A)
				speed = 1;
			if (sp.Key == ConsoleKey.B)
				speed = 2;
			if (sp.Key == ConsoleKey.C)
				speed = 3;
			if (sp.Key == ConsoleKey.D)
				speed = 4;
			Console.Clear();
			Game game = new Game();
			game.wall.Draw();
			Thread thread = new Thread(game.Move);
			thread.Start();
			while (true)
			{
				ConsoleKeyInfo pressed = Console.ReadKey();
				if (pressed.Key == ConsoleKey.UpArrow)
					d = 1;
				if (pressed.Key == ConsoleKey.DownArrow)
					d = 2;
				if (pressed.Key == ConsoleKey.RightArrow)
					d = 3;
				if (pressed.Key == ConsoleKey.LeftArrow)
					d = 4;
				if (pressed.Key == ConsoleKey.S)
					d = 5;
				if (pressed.Key == ConsoleKey.R)
					d = 6;
			}
		}
	}
}
