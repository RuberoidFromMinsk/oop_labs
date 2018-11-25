using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4new
{
    public class Matrix
    {
		public double[,] arr;

		public Matrix(int N, int M)
		{
			publishDate = new Date();
			owner = new Owner();
			arr = new double[N, M];
			Console.WriteLine("Введите матрицу");
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < M; j++)
				{
					arr[i, j] = double.Parse(Console.ReadLine());
				}
			}
		}

        public void Output()
		{
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for (int j = 0; j < arr.GetLength(1); j++)
				{
					Console.Write(arr[i, j] + "  ");
				}
				Console.WriteLine();
			}
		}


		public Owner owner { get; set; }
        public Date publishDate { get; }


		public static bool operator <(Matrix A, Matrix B)
        {
			if (A.arr.GetLength(0) != B.arr.GetLength(0))
				return false;
			if (A.arr.GetLength(1) != B.arr.GetLength(1))
                return false;
			for (int i = 0; i < A.arr.GetLength(0);i++)
			{
				for(int j = 0; j < A.arr.GetLength(0); j++)
				{
					if (A.arr[i, j] != B.arr[i, j])
						return false;
				}
			}
			return true;
        }

		public static bool operator >(Matrix A, Matrix B)
		{
			return false;
		}

		public static Matrix operator -(Matrix E)
		{
			for (int i = 0; i < E.arr.GetLength(0); i++)
			{
				for (int j = 0; j < E.arr.GetLength(1); j++)
				{
					if (i == j)
						E.arr[i, j] = 1;
					else
						E.arr[i, j] = 0;
				}
			}
			return E;
		}

		public static bool operator ==(Matrix A, Matrix B)
		{
			if (A.arr[0, 0] == B.arr[0, 0])
				return true;
			else
				return false;
		}

		public static bool operator !=(Matrix A, Matrix B)
        {
            if (A.arr[0, 0] != B.arr[0, 0])
                return true;
            else
                return false;
        }

        public static Matrix operator *(Matrix A, Matrix B)
		{
			for (int i = 0; i < A.arr.GetLength(0); i++)
            {
                for (int j = 0; j < A.arr.GetLength(1); j++)
                {
					A.arr[i, j] = -A.arr[i, j];
                }
            }
			return A;
		}
        

		public class Owner//2 ćwiczeń
        {
            static int count;
            readonly int id;
            string name;
            string organization;

            public int Id
            {
                get => id;
            }

            public string Name
            {
                get => name;
                set => name = value;
            }

            public string Organization
            {
                get => organization;
                set => organization = value;
            }

            static Owner()
            {
                count = 0;
            }

            public Owner()
            {
                this.id = count;
                this.name = "Uncknown";
                this.organization = "Uncknown";
				count++;
            }

            public Owner(string name, string organization) : this()
            {
                this.name = name;
                this.organization = organization;
            }
        }

		public class Date//3 ćwiczeń
        {
            private DateTime date;

            public DateTime PublishDate
            {
                get => date;
            }

            public Date()
            {
                date = DateTime.Now;
            }
        }
    }


	static class MathOperation//4 зад
    {
        public static void Max(Matrix A)
        {
			double max = -10000;

			for (int i = 0; i < A.arr.GetLength(0); i++)
			{
				for (int j = 0; j < A.arr.GetLength(1); j++)
				{
					if (A.arr[i, j] >= max)
						max = A.arr[i, j];
				}
			}
			Console.WriteLine("Макс элемент матрицы: " + max);
			
        }
        public static void Min(Matrix A)
        {
			double min = 10000;

            for (int i = 0; i < A.arr.GetLength(0); i++)
            {
                for (int j = 0; j < A.arr.GetLength(1); j++)
                {
                    if (A.arr[i, j] <= min)
                        min = A.arr[i, j];
                }
            }
            Console.WriteLine("Мин элемент матрицы: " + min);
        }
        public static void Length(Matrix A)
        {
			int lenght = A.arr.GetLength(0) + A.arr.GetLength(1);
			Console.WriteLine("Количество элементов матрицы: " + lenght);
        }

    }


	public static class Extclass
	{
		public static double Sum(this Matrix A)
		{
			double sum = 0;
			for (int i = 0; i < A.arr.GetLength(0); i++)
			{
				for (int j = 0; j < A.arr.GetLength(1); j++)
				{
					sum += A.arr[i, j];
				}
			}
			return sum;
		}
		public static double Minus(this Matrix A)
		{
			double total = 0;
			double x1 = 0;
			double x2 = 0;
			int counter = 0;
			for (int i = 0; i < 1; i++)
			{
				for (int j = 0; j < A.arr.GetLength(1); j++)
				{
					if (counter == 2)
						break;
					if (A.arr[i, j] == Math.Truncate(A.arr[i, j]))
					{
						if (counter == 0)
							x1 += A.arr[i, j];
						if (counter == 1)
							x2 += A.arr[i, j];
						counter++;
					}

                }
            }
			if (counter < 2)
				return 10101;//błąd
			total = x1 - x2;
			return total;
		}


       
	}

    class Program
    {
        static void Main(string[] args)
        {
		    Matrix matrix_1 = new Matrix(2, 2);
			Matrix matrix_2 = new Matrix(2, 2);

			matrix_1.owner.Name = "Andrew L.";
			matrix_1.owner.Organization = "@BSTU";
			Console.WriteLine("matrix_1 :" + matrix_1.owner.Name + " "+ matrix_1.owner.Organization + " " +matrix_1.owner.Id + " " + matrix_1.publishDate.PublishDate);
			Console.WriteLine("--------------\nMathOperation && Extension methods:");
			MathOperation.Max(matrix_1);
			MathOperation.Min(matrix_1);
			MathOperation.Length(matrix_1);
			Console.WriteLine("Сумма элементов матрицы 1 равна " + matrix_1.Sum());
			if(matrix_1.Minus() != 10101)
				Console.WriteLine("Разность первых двух целых чисел в строке " + matrix_1.Minus());
			else
				Console.WriteLine("В первой строке нет двух целых чисел");


			Console.WriteLine("--------------\nПерегрузка < :");
			if (matrix_1 < matrix_2)
				Console.WriteLine("Матрицы равны");
			else
				Console.WriteLine("Матрицы НЕ равны");
            
			Console.WriteLine("--------------\nПерегрузка * :");
			matrix_1 = matrix_1 * matrix_2;
            matrix_1.Output();


			Console.WriteLine("--------------\nПерегрузка - :");
			matrix_1 = -matrix_1;
			matrix_1.Output();

			Console.WriteLine("--------------\nПерегрузка == :");
			if (matrix_1 == matrix_2)
				Console.WriteLine("Матрицы равны по первому элементу");
			else
				Console.WriteLine("Матрицы НЕ равны по первому элементу");



			Console.ReadKey();
        }
    }
}
