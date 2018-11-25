using System;

namespace lab11
{
	public class BoolMatrix
    {
        private bool[,] arr;
		private int iSize;
		private int jSize;


        public BoolMatrix(int rows, int colums)
        {
			iSize = rows;
			jSize = colums;

			arr = new bool[iSize,jSize];
            
            Console.WriteLine("Введите матрицу");
			for (int i = 0; i < arr.GetLength(0); i++)
            {
				for (int j = 0; j < arr.GetLength(1); j++)
                {

                    String s = Console.ReadLine();
                    switch (s)
                    {
                        case "0":
                            {
                                arr[i,j] = false;
                                break;
                            }
                        default:
                            {
                                arr[i,j] = true;
                                break;
                            }
                    }
                }
            }
        }


		public int GetRows
		{
			get
			{
				return arr.GetLength(0);
			}
		}

		public int GetColums
        {
            get
            {
                return arr.GetLength(1);
            }
        }


        public int CountOfUnit()
        {
            int c = 0;
			for (int i = 0; i < arr.GetLength(0); i++)
            {
				for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i,j]) c++;
                }
            }
            return c;
        }
              
		public void Output()
        {
			Console.WriteLine();
			for (var i = 0; i < arr.GetLength(0); i++)
            {
				for (var j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i,j].ToString() + ' ');

                }
                Console.WriteLine();
            }
			Console.WriteLine();
        }


    }
}
