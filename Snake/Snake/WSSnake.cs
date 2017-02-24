using System;
using System.IO;
using System.Collections.Generic;
namespace Snake
{
	public class Wall : Fucntions
	{
		public Wall(string FileName)
		{
			sign = 'o';
			color = ConsoleColor.Red;
			body = new List<Point>();
			StreamReader sr = new StreamReader(FileName);
			int n = int.Parse(sr.ReadLine());
			for (int i = 0; i < n; ++i)
			{
				string s = sr.ReadLine();
				for (int j = 0; j < s.Length; j++)
				{
					if (s[j] == '*')
					{
						body.Add(new Point(j, i));
					}
				}
			}
		}
	}
}
