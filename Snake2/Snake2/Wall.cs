using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace Snake2
{
	public class Wall : All
	{
		public Wall()
		{
		}
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
		public Wall Resume()
		{
			FileStream fs = new FileStream("wall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
			XmlSerializer xs = new XmlSerializer(typeof(Wall));
			Wall s = (Wall)xs.Deserialize(fs);
			fs.Close();
			return s;
		}
	}
}
