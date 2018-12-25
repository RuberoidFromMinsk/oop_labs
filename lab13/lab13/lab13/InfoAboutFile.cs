using System;
using System.IO;

namespace lab13
{
    public class InfoAboutFile
    {
        public static void GetFileInfo(string arg)
		{
			Console.WriteLine("   ***   GetFileInfo   ***");
            
			System.IO.FileInfo file = new System.IO.FileInfo(arg);
            
			Console.WriteLine($"Имя: {file.Name}");
			Console.WriteLine($"Полный путь к файлу: {file.FullName}");
			Console.WriteLine($"Расширение: {file.Extension}");
			Console.WriteLine($"Размер: {file.Length}");
			Console.WriteLine($"Время создания: {file.CreationTime}");
            
			Console.WriteLine();
		}
    }
}
