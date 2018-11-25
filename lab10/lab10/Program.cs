using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab10
{
    partial class MainClass
	{
        public static void Main(string[] args)
        {   //1
			ArrayList list = new ArrayList();
			Student student = new Student("Vasya",18);
			Random random = new Random();
			string myString = "Here's a string";
			for (var i = 0; i < 5; i++) 
			{
				list.Add(random.Next(0, 100));
			}
			list.Add(myString);
			list.Add(student);
			list.RemoveAt(0);
			Console.WriteLine("Our Arraylist collection:\n");
			foreach (object o in list)
				Console.WriteLine(o);
			
			Console.WriteLine($"\nCount of elements: {list.Count}");

			for (var i = 0; i < list.Count; i++) 
			{
				if (list[i] == myString)
					Console.WriteLine("Строка myString найдена!");
				
			}


            //2
			MyDictionary<double, string> dictionary_1 = new MyDictionary<double, string>();
			double[] keys = { 1, 2.1 };
			dictionary_1.Add(1.5, "Hello");
			dictionary_1.Add(2.1, "World");
			dictionary_1.Add(1, "Banana");
			dictionary_1.Delete(1);

			foreach (KeyValuePair<double, string> pair in dictionary_1) 
            { 
               Console.WriteLine("{0}, {1}",  pair.Key, pair.Value); 
            }

			MyQueue<string> queue_1 = new MyQueue<string>();
			foreach (KeyValuePair<double, string> pair in dictionary_1)
				queue_1.Add(pair.Value);
			
			foreach (string item in queue_1)
				Console.WriteLine(item);

			string s = "Hello";
			foreach(string item in queue_1)
			{
				if (item == s)
					Console.WriteLine("An item has been finded in a queue");
				
			}


            //3
			MyDictionary<double, Student> dictionary_2 = new MyDictionary<double, Student>();
			Student student_1 = new Student("Petya", 20);
			Student student_2 = new Student("Masha", 17);

			dictionary_2.Add(1,student_1);
			dictionary_2.Add(2,student_2);

			MyQueue<Student> queue_2 = new MyQueue<Student>();
			foreach (KeyValuePair<double, Student> pair in dictionary_2)
                queue_2.Add(pair.Value);
            
			foreach (Student item in queue_2)
                Console.WriteLine(item);

			Student student_3 = new Student("Petya", 20);
			foreach (Student item in queue_2)
            {
				if ((item.Name == student_3.Name) && (item.Age == student_3.Age))
                    Console.WriteLine("Студент Петя уже существует!");
            }

            //4
			ObservableCollection<Student> students = new ObservableCollection<Student>
			{
				student_1,
				student_2
            };
			students.CollectionChanged += Students_CollectionChanged;
            
			students.Add(student_3);
			students.Remove(student_2);

			Console.ReadKey();
        }


		private static void Students_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Student newStudent = e.NewItems[0] as Student;
                    Console.WriteLine($"Добавлен новый объект: {newStudent.Name} - {newStudent.Age} лет");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Student oldStudent = e.OldItems[0] as Student;
                    Console.WriteLine($"Удален объект: {oldStudent.Name} - {oldStudent.Age} лет");
                    break;
            }
        }
    }
}
