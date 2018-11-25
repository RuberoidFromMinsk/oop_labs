using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    partial class BoolMatrix
    {
		private bool[][] arr;
        private int someNuuum;
		private readonly int r;
        static int count = 0;
		static readonly long baseline;
        private const string L = "BoolMatrix";

        //constructors
        public BoolMatrix(int someNum)
        {
            this.someNuuum = someNum;
        }


		public BoolMatrix(double x = 1){
			this.someNuuum = (int)x;
		}


        private BoolMatrix(string L)
        {
            Console.WriteLine("Закрытый конструктор");
		}


        public BoolMatrix()
        {
            arr = new bool[3][];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new bool[3];
            }
            Console.WriteLine("Введите матрицу");
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {

                    String s = Console.ReadLine();
                    switch (s)
                    {
                        case "0":
                            {
                                arr[i][j] = false;
                                break;
                            }
                        default:
                            {
                                arr[i][j] = true;
                                break;
                            }
                    }
                }
            }

            count++;
        }


		static BoolMatrix()
        {
            baseline = DateTime.Now.Ticks;
        }


        //override
        public override int GetHashCode()
        {
			int hash = (arr.GetHashCode() + count.GetHashCode()) / 2;
            return hash;
        }


        public override string ToString()
        {
            return arr.Length.ToString();
        }


        public override Boolean Equals(Object obj)
        {

            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            return true;
        }

        //Methods
        public void Disn(BoolMatrix a)
        {
            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i][j] == true || a.arr[i][j] == true) arr[i][j] = true;
                    else arr[i][j] = false;
                }
        }
        public void Con(BoolMatrix a)
        {

            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i][j] == false || a.arr[i][j] == false) arr[i][j] = false;
                    else arr[i][j] = true;

                }

        }
		public bool List(bool buff)
		{
			int[] counter1 = new int[arr.Length];

			int result = 0;
			for (int i = 0; i < counter1.Length;i++)
			{
				counter1[i] = 0;

			}
			for (int i = 0; i < arr.Length; i++)
				for (int j = 0; j < arr.Length;j++)
			    {
				    if(arr[i][j] == buff)
				    {
						counter1[i]++;
				    }
				    			    
			    }
			for (int i = 0; i < arr.Length; i++)
				if (counter1[0] == counter1[i])
					result++;
			if (result == arr.Length)
				return true;
			else
			    return false;
		}
        public void In()
        {

            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr.Length; j++)
                {
                    arr[i][j] = !arr[i][j];
                }
        }
        public int unit()
        {
            int c = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i][j]) c++;
                }
            }
            return c;
        }
		public void Output()
		{
			for (var i = 0; i < arr.Length;i++)
			{
				for (var j = 0; j < arr.Length; j++)
				{
					Console.Write(arr[i][j].ToString() + ' ');

				}
				Console.WriteLine();
			}
		}
        public void refincr(ref int i)
        {
            i++;
        }

        public void refnull(out int i)
        {

            i = 0;
        }


		public int Value
        {
			get { return someNuuum; }
			set { this.someNuuum = value >= 0 ? value : 0; }
         
        }	

		public static void Inf()
        {
            Console.WriteLine("Количество экземпляров класса " + L + ": " + count);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BoolMatrix[] a = new BoolMatrix[2];
            a[0] = new BoolMatrix();
            a[1] = new BoolMatrix();

			if (a[0].List(true) == true)//zadanie2
				Console.WriteLine("Кол-во true в каждой строке равно");
			else
				Console.WriteLine("Кол-во true в каждой строке HE равно");


            BoolMatrix.Inf();
            a[0].Disn(a[1]);
			Console.WriteLine("Матрица 0 после дизъюнкции:");
			a[0].Output();
            a[0].Con(a[1]);
			Console.WriteLine("Матрица 0 после konъюнкции:");
			a[0].Output();
            a[0].In();
			Console.WriteLine("Матрица 0 после инверсии:");
			a[0].Output();
            if (a[0].Equals(a[1])) Console.WriteLine("Матрицы равны");
            else Console.WriteLine("Матрицы не равны");
            if (a[0].unit() > a[1].unit()) Console.WriteLine("В матрице 0 единиц больше");
            else if (a[0].unit() == a[1].unit()) Console.WriteLine("Количество единиц в матрицах равно");
            else Console.WriteLine("В матрице 1 единиц больше");
            var sometype = new { arr = a[0] };

        }
    }
}
