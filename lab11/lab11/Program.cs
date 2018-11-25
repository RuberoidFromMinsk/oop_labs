using System;
using System.Linq;
using System.Collections.Generic;

namespace lab11
{
    class MainClass
    {
		
        public static void Main(string[] args)
        {
			
			string[] months = {"June", "July", "August",
				               "September", "October", "November",
				               "December", "January", "February", 
				               "March", "April", "May"};
			
			var selectedMonths_1 = from t in months 
					               where t.Length == 5 
			                       select t;
			
			var selectedMonths_2 = from t in months
					               where t == "June" || t == "July" || t == "August" || t == "December" || t == "January" || t == "February"
			                       select t;
          
			var selectedMonths_3 = from t in months 
				                   orderby t 
				                   select t;

			var selectedMonths_4 = from t in months 
					               where t.Contains('u') && t.Length >= 4
			                       select t;

			foreach (var item in selectedMonths_1)
				Console.WriteLine(item);
			Console.WriteLine("-----");
			foreach (var item in selectedMonths_2)
                Console.WriteLine(item);
			Console.WriteLine("-----");
            foreach (var item in selectedMonths_3)
                Console.WriteLine(item);
			Console.WriteLine("-----");
			Console.WriteLine("Count of months that contain 'u': " + selectedMonths_4.Count());
			Console.WriteLine("\n\n");


            
			List<BoolMatrix> list = new List<BoolMatrix>();
			BoolMatrix matrix_1 = new BoolMatrix(2,3);
			BoolMatrix matrix_2 = new BoolMatrix(3,3);
			BoolMatrix matrix_3 = new BoolMatrix(2,2);

       
			list.Add(matrix_1);
			list.Add(matrix_2);
			list.Add(matrix_3);

			//****
			var sortByUnits = from t in list
							  orderby t.CountOfUnit()
							  select t;
          
			Console.WriteLine("\nСортировка по кол-ву единиц:");
			foreach(var item in sortByUnits)
				item.Output();
			
            //****
			var maxUnits = sortByUnits.Reverse().Take(1);
			var check = sortByUnits.Reverse().Skip(1).Take(1);

			bool forChecking = false;
			foreach (var item in maxUnits)
			{
				foreach (var chk in check)
                {
                    
                    if (item.CountOfUnit() == chk.CountOfUnit())
                        forChecking = false;
                    else
                        forChecking = true;
                }
			}

			if (forChecking)
			{
				Console.WriteLine("Максимум единиц в матрице: ");
				foreach (var item in maxUnits)
					item.Output();
			}
			else
				Console.WriteLine("В двух или более матрицах кол-во true равно!");

				
            //*****
			int rows = 2;
			int colums = 3;
			var currentSizeMatrix = from t in list 
					                where t.GetRows == rows && t.GetColums == colums
			                        select t;
			
			Console.WriteLine("Количество матриц указанного размера: " + currentSizeMatrix.Count());

			//*****
            var getSizes = from item in list
                           orderby item.GetRows * item.GetColums
                           select item;

            var getMaxSize = getSizes.Reverse().Take(1);

            Console.WriteLine("\nМаксимальная матрица:");
            foreach (var item in getMaxSize)
                item.Output();

                     
			//*********
			Console.WriteLine("Матрицы с равным кол-вом единиц: ");
			var countsInList = from item in list orderby item.CountOfUnit() select item.CountOfUnit();

			var query = countsInList.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();

			var selectedMatrix = from item in list where item.CountOfUnit() == query.FirstOrDefault() select item;
              

			foreach (var t in selectedMatrix)
				t.Output();


     //Operator Join
			List<Team> teams = new List<Team>()
            {
                new Team { Name = "Dortmund", Country ="Germany" },
                new Team { Name = "Barcelona", Country ="Spain" }
            };
            List<Player> players = new List<Player>()
            {
                new Player {Name="Ter Stegen", Team="Barcelona"},
                new Player {Name="Messi", Team="Barcelona"},
                new Player {Name="Goetze", Team="Dortmund"}
            };

            var result = from pl in players
                         join t in teams on pl.Team equals t.Name
                         select new { Name = pl.Name, Team = pl.Team, Country = t.Country };

            foreach (var item in result)
                Console.WriteLine("{0} - {1} ({2})", item.Name, item.Team, item.Country);

            //****
			int[] myArr = { 1, 3, 6, 8, 0, 4, 6, 8, 13, 5, 78, 45, -4 };
			var sortedArr = from item in myArr
				            orderby item
			                select item;
			
			var myRequest = sortedArr.Distinct().Reverse().Take(10);
			foreach (int item in myRequest)
				Console.Write(item + "  ");

            
			Console.ReadKey();
        }
    }
}
