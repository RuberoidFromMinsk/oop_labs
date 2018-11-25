using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {

        public abstract class Aviation
        {
            protected string _name;

			public Aviation(string _name)
            {
                this._name = _name;
            }


            public virtual void GetName()
            {
                Console.WriteLine("Name:" + _name);
            }
			public abstract int GetCapacity();
			public abstract int GetCarrying();
			public abstract int GetDistance();
            public abstract void Display();
        }
		public class PassangerPlane : Aviation
        {
			public int passangerCapacity;

			public PassangerPlane(int passangerCapacity, string _name) : base(_name)
			{
				this.passangerCapacity = passangerCapacity;
			}

            public override void GetName()
            {
				Console.WriteLine($"Passanger plane: {_name}");
            }
            
            public override int GetCapacity()
			{
				return passangerCapacity;
			}
			public override int GetCarrying()
			{
				throw new NotImplementedException();
			}
			public override int GetDistance()
			{
				throw new NotImplementedException();
			}
			public override void Display()
            {
				Console.WriteLine($"Passanger capacity: {passangerCapacity}   Name:{_name} Type: {this.GetType()}");
            }
        }
        public class CargoPlane : Aviation
        {
			public int carrying;

			public CargoPlane(int carrying, string _name) : base(_name)
            {
				this.carrying = carrying;
            }
			public override int GetCapacity()
            {
                return 0;
            }
			public override int GetCarrying()
			{
				return carrying;
			}
			public override int GetDistance()
			{
				throw new NotImplementedException();
			}
			public override void Display()
            {
				Console.WriteLine($"Carrying: {carrying}  Name: {_name}");
            }
        }
        public class MilitaryPlane : Aviation
        {
			int distance;
			bool weapons;
            
			public MilitaryPlane(int distance, bool weapons, string _name) : base(_name)
            {
				this.distance = distance;
				this.weapons = weapons;
            }
			public override int GetCapacity()
            {
                return 0;
            }
			public override int GetCarrying()
            {
                return 0;
            }
			public override int GetDistance()
			{
				return distance;
			}
			public override void Display()
            {
				Console.WriteLine($"Flight distance: {distance}  Weapons: {weapons}  Name: {_name}");
            }
        }

		sealed class Boeing : PassangerPlane
        {
            int age { get; set; }
            static int counter = 0;

            public Boeing(int age, int passangerCapacity, string _name) : base(passangerCapacity, _name)
            {
                this.age = age;
                counter++;
            }

			public override void Display()
            {
				Console.WriteLine($"Age: {age}  Passanger Capacity: {passangerCapacity}  Name: {_name}");
            }
            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                Boeing c = obj as Boeing;
                if (c as Boeing == null)
                    return false;

                return this == (Boeing)obj;
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            public override string ToString()
            {
                return "Name: " + _name + " Age: " + age;
            }
        }
		interface IName1
        {
            void GetName();
        }
        interface IName2
        {
            void GetName();
        }
		sealed class TU134: PassangerPlane, IName1, IName2
        {
			int age { get; set; }
            static int counter = 0;

			public TU134(int age, int passangerCapacity, string _name) : base(passangerCapacity, _name)
            {
                this.age = age;
                counter++;
            }

			void IName1.GetName()
			{
				Console.WriteLine("I'm going to IName1");
			}
			void IName2.GetName()
            {
                Console.WriteLine("I'm going to IName2");
            }

			public override void Display()
            {
                Console.WriteLine($"Age: {age}   Passanger Capacity: {passangerCapacity}    Name: {_name}");
            }
        }
              
        
        class Print
        {
            public static void IamPrinting(Aviation obj)
            {
                Console.WriteLine("\nТип:" + obj.GetType());
				obj.Display();
				Console.WriteLine();
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

				if (arr[0] is Aviation)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
						Aviation x = arr[i] as Aviation;
						x.GetName();
                    }
                }
                
            }
			int this[int i]
            {
                get
                {
					if (arr[i] is PassangerPlane)
                    {
						PassangerPlane x = arr[i] as PassangerPlane;
						return x.passangerCapacity;
                    }
					else
                    {
                        CargoPlane y = arr[i] as CargoPlane;
                        return y.carrying;
                    }
                    
                }
            }
        }

		class Controller
		{
           
			public static void GenerallPasCapacity(Container<Aviation> c)
			{
				int passSum = 0;
				Container<Aviation> p = new Container<Aviation>();
				for (int i = 0; i < c.arr.Length; i++)
				{
					if (c.arr[i] is PassangerPlane) p.add(c.arr[i]);
				}
				for (int i = 0; i < p.arr.Length; i++)
				{
					passSum += p.arr[i].GetCapacity();
				}
				Console.WriteLine("Total capacity: " + passSum);
			}

			public static void GenerallCarrying(Container<Aviation> c)
            {
                int totalCargo = 0;
                Container<Aviation> p = new Container<Aviation>();
                for (int i = 0; i < c.arr.Length; i++)
                {
					if (c.arr[i] is CargoPlane) p.add(c.arr[i]);
                }
                for (int i = 0; i < p.arr.Length; i++)
                {
					totalCargo += p.arr[i].GetCarrying();
                }
				Console.WriteLine("Total cargo load: " + totalCargo);
            }
			public static void SortingByDescending(Container<Aviation> c)
			{
				int buff;

				Container<Aviation> p = new Container<Aviation>();
				for (int i = 0; i < c.arr.Length; i++)
                {
					if (c.arr[i] is MilitaryPlane) p.add(c.arr[i]);
                }
				int[] distances = new int[p.arr.Length];
				for (int i = 0; i < p.arr.Length; ++i)
				{
					distances[i] = p.arr[i].GetDistance();
				}
				for (int i = 1; i < p.arr.Length; i++)
                {
					for (int r = 0; r < p.arr.Length - i; r++)
					{
						if (distances[r] < distances[r + 1])
                        {
                            buff = distances[r];
                            distances[r] = distances[r + 1];
                            distances[r + 1] = buff;
                        }
					}

                }
				for (int i = 0; i < p.arr.Length; i++)
                {
					Console.WriteLine(distances[i]);
					//Console.WriteLine(p.arr[i].Display());
                }
               
			}
		}


        static void Main(string[] args)
        {

            
			var pasPlane = new PassangerPlane(500, "Airplane");
			var militarPlane = new MilitaryPlane(2000, true, "F15");
			var boeingPlane = new Boeing(9, 450, "SARL 0ER5");
			var plane = new TU134(15, 250, "AR 220");

			pasPlane.Display();

			var newPasPlane = pasPlane as Aviation;
			if (newPasPlane != null)
				Console.WriteLine("Я преобразован в Aviation");
			else
				Console.WriteLine("Ooops!");

			if (militarPlane is Aviation)
				Console.WriteLine("Объект может быть преобразован в тип Aviation");
			else
				Console.WriteLine("militarPlane ne может быть преобразован в тип Aviation");
        
			((IName1)plane).GetName();
            ((IName2)plane).GetName();
            
			Print.IamPrinting(pasPlane);
			Print.IamPrinting(plane);
            //End of 5lab.

            //6 lab has been started
			Container<Aviation> contain = new Container<Aviation>();
			contain.add(new PassangerPlane(480, "Airbus A370"));
			contain.add(new PassangerPlane(100, "YAK 40"));
			contain.add(new Boeing(15,400,"Boeing 747"));
			contain.add(new TU134(20, 145, "TU_134"));
			contain.add(new MilitaryPlane(750, true, "F15"));
			contain.add(new MilitaryPlane(900, true, "Eurofighter"));

			Controller.GenerallPasCapacity(contain);
			Controller.SortingByDescending(contain);

			Console.ReadKey();
        }
    }
}
