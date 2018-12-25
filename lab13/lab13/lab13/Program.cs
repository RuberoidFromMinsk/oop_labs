using System;

namespace lab13
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			string file = @"C:\for13lab\myfile.txt";
			string directory = @"C:\for13lab";

			DiskInfo.GetFreeSpace();
			DiskInfo.GetFilesystemType();
			DiskInfo.GetReadyDiskInfo();
			InfoAboutFile.GetFileInfo(file);
			InfoAboutDirectory.GetDirectoryInfo(directory);

            Log log = new Log();
            log.Read();
            Console.WriteLine(DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
            log.Search();
            log.DeleteTime();


            FileManager manager = new FileManager();
            manager.Worker();

			Console.ReadKey();
        }
    }
}
