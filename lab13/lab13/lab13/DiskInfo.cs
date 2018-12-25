using System;
using System.IO;

namespace lab13
{
    public class DiskInfo
    {
		public static void GetFreeSpace()
		{
			Console.WriteLine("   ***   GetFreeSpace   ***");

			DriveInfo[] drives = DriveInfo.GetDrives();

			foreach (DriveInfo drive in drives)
            {
				Console.WriteLine($"Название: {drive.Name}");     
				Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");

				Console.WriteLine();
            }
		}

		public static void GetFilesystemType()
		{
			Console.WriteLine("   ***   GetFilesystemType   ***");

			DriveInfo[] drives = DriveInfo.GetDrives();

			foreach (DriveInfo drive in drives)
            {
				Console.WriteLine($"Тип: {drive.DriveType}");

				Console.WriteLine();
            }
		}

		public static void GetReadyDiskInfo()
		{
			{
				Console.WriteLine("   ***   GetReadyDiskInfo   ***");

                DriveInfo[] drives = DriveInfo.GetDrives();
                
                foreach (DriveInfo drive in drives)
                {   
                    if (drive.IsReady)
                    {
						Console.WriteLine($"Название: {drive.Name}");
						Console.WriteLine($"Объем диска: {drive.TotalSize}");
						Console.WriteLine($"Доступный объём: {drive.TotalFreeSpace}");
						Console.WriteLine($"Метка: {drive.VolumeLabel}");
                    }
                    Console.WriteLine();
                }

                Console.ReadLine();
            }
		}
    }
}
