using System;
using System.Collections;
namespace lab10
{
	public class Student:IComparable
    {
		private string _name;
		private int _age;

		public string Name { get => _name; set => _name = value; }
		public int Age { get => _age; set => _age = value; }

		public Student(string name, int age)
        {
			_name = name;
			_age = age;
        }

		public override string ToString()
		{
			return "Студент " + Name + " - " + Age + " лет";
		}

		public int CompareTo(object obj)
        {
			Student student = obj as Student;
			if (student != null)
				return this.Name.CompareTo(student.Name);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
	}
}
