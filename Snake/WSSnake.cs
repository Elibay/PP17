using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
namespace Snake
{
	public class Wall
	{
		List<Point> body;
		public char sign = 'o';
		public ConsoleColor color = ConsoleColor.Red;
		public Wall()
		{
			body = new List<Point> ();
			StreamReader sr = new StreamReader("wall.txt");
			int n = int.Parse(sr.ReadLine());
			for (int i = 0; i < n; ++i)
			{
				string s = sr.ReadLine();
				//Console.WriteLine(s);
				for (int j = 0; j < s.Length; j ++)
				{
					//Console.WriteLine(s[j]);
					if (s[j] == '*')
						body.Add(new Point(j, i));
				}
			}
		}
		public void Draw()
		{
			//Console.Clear();
			Console.ForegroundColor = color;
			foreach (Point p in body)
			{
				Console.SetCursorPosition(p.x, p.y);
				Console.Write(sign);
			}
			//Console.ForegroundColor = ConsoleColor.Red;
		}
	}
}
