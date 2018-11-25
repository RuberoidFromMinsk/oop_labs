using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab6
{
    class Program
    {
        public abstract class Ground
        {
            protected Country c;
            protected int square;
            public String name { protected set; get; }
            
            
            public virtual void getName()
            {
                Console.WriteLine("Остров: " + name);
            }
            public Ground(int s, string n)
            {
                square = s;
                name = n;
            }
            public abstract void toString();
            public void getCountry()
            {
                Console.WriteLine(c.name);
            }

        }
        public class Continent : Ground
        {

            public override void getName()
            {
                Console.WriteLine("Континент: " + name);
            }

            public Continent(int s, string n, Country cy) : base(s, n)
            {


                c = cy;
            }
            public override void toString()
            {
                Console.WriteLine("square:" + square + "name:" + name + "country:" + c.name);
            }


        }
   //!
		public class City
        {
            public int population;
            public int square;

			public City(int population, int square)
            {
				this.population = population;
				this.square = square;
            }

            public void CheckSquare()
            {
				if (square < 0) { throw new ChildException("Площадь меньше нуля!"); }
            }

            public void CheckSquare2()
            {
				if (square > 0 && square < 10) { throw new ChildException1("Слишком малая площадь"); }
            }

            public void CheckPopulation()
            {
				if (population < 0) { throw new ChildException2("В городе отрицательное население!"); }
            }
        }


		public class ChildException : Exception
        {
            public ChildException(string msg) : base(msg) { Console.WriteLine(); }
        }

        public class ChildException1 : Exception
        {
            public ChildException1(string msg) : base(msg) { Console.WriteLine(); }
        }

        public class ChildException2 : Exception
        {
            public ChildException2(string msg) : base(msg) { Console.WriteLine(); }
        }

   //!
        class Island : Ground
        {

            public Island(int s, string n, Country cy) : base(s, n)
            {
                c = cy;
            }
            public override void toString()
            {
                Console.WriteLine("square:" + square + "name:" + name);
            }

        }
        interface Water
        {
            void getName();

        }
        sealed class Sea : Water
        {
            string name;
            public void getName()
            {
                Console.WriteLine(name);
            }
            public Sea(string n)
            {
                name = n;
            }
            public void toString()
            {
                Console.WriteLine("name:" + name);
            }
        }
        struct Lake : Water
        {
            string name;
            public Lake(string n)
            {
                name = n;
            }
            public void getName()
            {
                Console.WriteLine(name);
            }
        }
        enum Satte
        {
            Poland,
            Ukraine,
            Belarus
        }
        public partial class Country
        {
            public string name { protected set; get; }
            public Country(string n)
            {
                name = n;
            }
            public Country()
            {

            }
            public override bool Equals(object obj)
            {
                if (obj == null) return false;

                if (this.GetType() != obj.GetType()) return false;
                Country c = (Country)obj;
                return c.name == name;

            }


            public override int GetHashCode()
            {
                return name.GetHashCode() + 1;
            }


        }
        class Print
        {
            public static void iAmPrinting(Ground g)
            {
                Console.WriteLine("Тип:" + g.GetType());
                g.toString();
            }
            public static void iAmPrinting(Water w)
            {
                Console.WriteLine("Тип:" + w.GetType() + w.ToString());
            }
        }
        class Container<T>
        {
            public T[] arr { private set; get; } = null;
            public void add(T g)
            {
                T[] a = null;
                if (arr == null) arr = new T[1];
                else
                {
                    a = arr;
                    arr = new T[a.Length + 1];
                }
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (a != null) arr[i] = a[i];
                }
                arr[arr.Length - 1] = g;
            }
            public void remove(T g)
            {
                T[] a = new T[arr.Length - 1];
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = arr[i];
                }
                arr = a;
            }
            public void print()
            {

                if (arr[0] is Ground)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        Ground x = arr[i] as Ground;
                        x.getName();

                        x.getCountry();

                    }
                }
                
            }
            String this[int i]
            {
                get
                {
                    if (arr[i] is Ground)
                    {
                        Ground x = arr[i] as Ground;
                        return x.name;
                    }
                    else
                    {
                        Island x = arr[i] as Island;
                        return x.name;
                    }
                }
            }
        }

        class Controller
        {
            public static void Islands(Container<Ground> c)
            {
                Container<Ground> p = new Container<Ground>();
                for (int i = 0; i < c.arr.Length; i++)
                {
                    if (c.arr[i] is Island) p.add(c.arr[i]);
                }
                for (int i = 0; i < p.arr.Length; i++)
                {
                    int z = 0;
                    for (int j = 0; j < p.arr.Length; j++)
                    {
                        if (i == j) continue;
                        if (Compare(p.arr[i], p.arr[j]) == 1) z++;

                    }
                    Island isl = p.arr[z] as Island;
                    p.arr[z] = p.arr[i];
                    p.arr[i] = isl;
                }
                p.print();
            }
            public static void SeaC(Container<Water> c)
            {
                int z = 0;
                for (int i = 0; i < c.arr.Length; i++)
                {
                    if (c.arr[i] is Sea) z++;
                }
                Console.WriteLine("Количество морей " + z);
            }
            public static int Compare(object obj1, object obj2)
            {
                Ground g1 = obj1 as Ground;
                Ground g2 = obj2 as Ground;
                int i = 0;
                do
                {
                    if (g1.name[i] > g2.name[i]) return 1;
                    else
                    {
                        if (g1.name[i] < g2.name[i]) return -1;
                        else
                        {
                            i++;
                            continue;
                        }
                    }
                } while (true);
            }
        }
        


        static void Main(string[] args)
        {
            Container<Ground> c = new Container<Ground>();
            c.add(new Continent(750, "Europe", new Country("Germany")));
            c.add(new Continent(1500, "Asia", new Country("China")));
            c.add(new Island(10, "Ireland", new Country("Ireland")));
            c.add(new Island(10, "Iceland", new Country("Iceland")));
            c.add(new Island(200, "Greenland", new Country("Denmark")));
            Controller.Islands(c);
            Console.WriteLine();
            Container<Water> s = new Container<Water>();
            s.add(new Sea("North"));
            s.add(new Lake("Naroch"));
            s.add(new Sea("Baltic"));
            Controller.SeaC(s);
          
            
            //7
      
			int[] aa = null;
            Debug.Assert(aa != null, "Values array cannot be null");

           
            City eqpex = new City(100000,-5);
			City xepqe = new City(-5, 5);
            
            try
            {
				eqpex.CheckSquare();
				xepqe.CheckSquare2();
				xepqe.CheckPopulation();
            }
            //на основе своих исключений
            catch (ChildException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (ChildException1 e)
            {
                Console.WriteLine(e.Message);
            }

            catch (ChildException2 e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                int[] ArrForException = { 1, 2, 3, 4 };
                int g = ArrForException[7];
                int a = 1;
                int b = 0;
                int z = a / b;


            }
            //на основе стандартных исключений
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            finally
            {
                Console.WriteLine("This is Finally");
            }

            Console.ReadKey();
            
            
            
        }
    }
}

