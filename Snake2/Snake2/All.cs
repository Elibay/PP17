using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Snake2
{
	public class All
	{
		public List<Point> body;
		public char sign;
		public ConsoleColor color;
		public void Draw()
		{
			Console.ForegroundColor = color;
			foreach (Point p in body)
			{
				Console.SetCursorPosition(p.x, p.y);
				Console.Write(sign);
			}
			Console.CursorVisible = false;
		}
		public void Erase()
		{
			foreach (Point p in body)
			{
				Console.SetCursorPosition(p.x, p.y);
				Console.Write(' ');
			}
			Console.CursorVisible = false;
		}

		public void Save()
		{
			try
			{
				string fileName = this.GetType().Name + ".xml";
				File.Delete(fileName);
				FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
				XmlSerializer xs = new XmlSerializer(this.GetType());
				xs.Serialize(fs, this);
				fs.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: " + e.ToString());
				Console.ReadKey();
			}
		}

		/*public All Resume()
		{
			string fileName = this.GetType().Name + ".xml";
			FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			XmlSerializer xs = new XmlSerializer(this.GetType());
			All s = null;
			//Console.WriteLine(fileName);
			//Console.ReadKey();
			if (this.GetType() == typeof(Food))
				s = (Food)xs.Deserialize(fs);
			if (this.GetType() == typeof(Snake))
				s = (Snake)xs.Deserialize(fs);
			if (this.GetType() == typeof(Wall))
				s = (Wall)xs.Deserialize(fs);

			fs.Close();
			return s;
		}
		*/

	}
}