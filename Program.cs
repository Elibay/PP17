using System;

namespace Student
{
	class MainClass
	{
		public class Student
		{
			public string name, surname;
			public int age;
			public Student(string name, string surname, int age)
			{
				this.name = name;
				this.surname = surname;
				this.age = age;
			}
			public override string ToString()
			{
				return name + " " + surname + " " + age;
			}
		}
		static void Main(string[] args)
		{
			Student a = new Student("Aidos", "Nurmash", 21);
			Student b = new Student("Temirulan", "Mussayev", 22);
			Console.WriteLine(a);
			Console.WriteLine(b);
		}
	}
}