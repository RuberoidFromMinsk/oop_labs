using System;
using System.IO;

namespace lab13
{
    public class InfoAboutDirectory
    {
		public static void GetDirectoryInfo(string arg)
		{
			Console.WriteLine("   ***   GetDirectoryInfo   ***");

			DirectoryInfo directory = new DirectoryInfo(arg);

			Console.WriteLine($"Название каталога: {directory.Name}");
			Console.WriteLine($"Список родительских директориев: {directory.FullName}");
			Console.WriteLine($"Время создания каталога: {directory.CreationTime}");
			Console.WriteLine($"Корневой каталог: {directory.Root}");
			Console.WriteLine($"Количество файлов: {directory.GetFiles().Length}");
			Console.WriteLine($"Количество поддиректориев: {directory.GetDirectories().Length}");

			Console.WriteLine();
		}
    }
}
