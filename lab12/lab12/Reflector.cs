using System.IO;
using System.Reflection;
using System.Linq;
using System;
using System.Collections;

namespace lab12
{
    public class Reflector
    {
        public static void All(Type t)
        {
            MemberInfo[] members = t.GetMembers();

            string s = "";
            int count = members.Length;

            foreach (MemberInfo item in members)
            {
                s += (item.Name + "\n");
            }

            string path = @"/home/andrew/Projects/lab12/lab12/info.txt";

            using (StreamWriter sr = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sr.Write(s);
                sr.WriteLine("\nКоличество item'ов : " + count);
            }

        }

        public static void ShowAllMethods<T>(T obj) where T : class
        {
            Type all = typeof(T);

            MethodInfo[] MArr = all.GetMethods();
			Console.WriteLine($"*** Список методов класса {obj} ***\n");

            foreach (MethodInfo m in MArr)
            {
                Console.Write(" --> " + m.ReturnType.Name + " \t" + m.Name + "(");

                ParameterInfo[] p = m.GetParameters();
                for (int i = 0; i < p.Length; i++)
                {
                    Console.Write(p[i].ParameterType.Name + " " + p[i].Name);
                    if (i + 1 < p.Length) Console.Write(", ");
                }
                Console.Write(")\n");
            }
			Console.WriteLine();
        }

		public static void ShowAllFields<T>(T obj) where T : class
		{
			Type all = typeof(T);
			FieldInfo[] arr = all.GetFields();

			Console.WriteLine($"*** Список полей класса {obj} ***\n");
			foreach (FieldInfo m in arr)
                Console.Write(" --> " + m.Name + "\n");
			
			Console.WriteLine();  
		}

		public static void ShowAllProperties<T>(T obj) where T : class
		{
			Type all = typeof(T);
			PropertyInfo[] arr = all.GetProperties();

			Console.WriteLine($"*** Описание свойств класса {obj} ***\n");
			foreach (PropertyInfo m in arr)
				Console.WriteLine($" --> {m.MemberType} {m.Name} contains in {m.Module}");

            Console.WriteLine();
		}

		public static void ShowAllInterfaces<T>(T obj) where T : class
        {
            Type all = typeof(T);
			var arr = all.GetInterfaces();

            Console.WriteLine($"*** Интерфейсы класса {obj} ***\n");
            foreach (var m in arr)
				Console.Write($" --> {m.Name} , {m.IsInterface}\n");

            Console.WriteLine();
        }


        public static void FindMethodsByParam(Type t, Type pt)
        {
            MethodInfo[] s = t.GetMethods();
            ParameterInfo[] p;

            Console.WriteLine($"*** Методы с параметром string ***\n");
            for (int i = 0; i < s.Length; i++)
            {
                p = s[i].GetParameters();
                foreach (ParameterInfo j in p)
                {
                    if (j.ParameterType == pt)
                    {
                        Console.WriteLine(s[i].Name);
                        break;
                    }
                }
            }
            Console.WriteLine();
        }


        public static void Method(Type t, string m)
        {
            Console.WriteLine("*** Вызвать метод по параметру ***\n");

            MethodInfo mt = t.GetMethod(m);
            int capacity;
            string name;

            PassangerPlane samolot = new PassangerPlane(10,"samolot");

            string path = @"/home/andrew/Projects/lab12/lab12/param.txt";

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                capacity = Int32.Parse(sr.ReadLine());
                name = sr.ReadLine();
            }

            PassangerPlane nowySamolot = new PassangerPlane(capacity,name);

            PassangerPlane[] ca = new PassangerPlane[1] { nowySamolot };

            if ((bool)mt.Invoke(samolot, ca)) 
                Console.WriteLine("Самолеты равны по вместимости");
            else 
                Console.WriteLine("Самолеты НЕ равны по вместимости");
        }

    }
}
