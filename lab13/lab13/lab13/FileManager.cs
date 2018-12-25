using System;
using System.IO;
using System.IO.Compression;

namespace lab13
{
    class FileManager : Log
    {
        private string disk = "C://for13lab";
        private DirectoryInfo[] directory;
        private System.IO.FileInfo file;
        private string[] directories;
        private string[] files;

        public FileManager()
        {
            Add("Получаем файлы и директории в " + disk);
            directories = Directory.GetDirectories(disk);
            files = Directory.GetFiles(disk);
            directory = new DirectoryInfo[2];
            directory[0] = new DirectoryInfo("C://for13lab//Inspect");
            directory[1] = new DirectoryInfo("C://for13lab//Files");

            if (directory[0].Exists)
            {
                Add(directory[0].ToString() + " - существует. Удаляем.");
                directory[0].Delete(true);
            }

            if (directory[1].Exists)
            {
                Add(directory[1].ToString() + " - существует. Удаляем.");
                directory[1].Delete();
            }
        }
        public void Worker()
        {
            directory[0].Create();
            directory[1].Create();

            file = new System.IO.FileInfo("C://for13lab//Inspect//dirinfo.txt");
            Add("Создаем файл" + file.ToString());
            Add("Записываем информацию о файлах и папках в " + file.ToString());
            using (StreamWriter fs = new StreamWriter(file.ToString(), true, System.Text.Encoding.Default))
            {
                foreach (string s in files)
                {
                    fs.WriteLine(s);
                }
                foreach (string s in directories)
                {
                    fs.WriteLine(s);
                }
                Console.WriteLine("Текст записан в файл.");
            }

            FileInfo newdirinfo = new FileInfo("C://for13lab//NEWdirinfo.txt");

            if(!newdirinfo.Exists)
            {
                Add("Копируем dirinfo и удаляем его");
                file.CopyTo("C://for13lab//NEWdirinfo.txt");
                file.Delete();
            }


            DirectoryInfo fotos = new DirectoryInfo("C://for13lab//Fotos");
            Add("Получаем информацию о png файлах в " + fotos.ToString());

            System.IO.FileInfo[] jpegFiles = fotos.GetFiles("*.png");

            Add($"Копируем файлы png из {fotos.ToString()} в Inspect");

            foreach (System.IO.FileInfo file in jpegFiles)
            {
                file.CopyTo("C://for13lab//Inspect//" + file.Name, true);
            }

            Add("Перемещаем " + directory[1].ToString() + " в " + directory[0].ToString());

            directory[1].MoveTo("C://for13lab//Inspect//Files//");

            //ZipFile.CreateFromDirectory(directory[0].ToString(), "C://myArchive.zip");
            //ZipFile.ExtractToDirectory("C://myArchive.zip", "C://unzip");

            Compress("C://for13lab/myfile.txt", "C://for13lab/file.gz");
            Add("Файл сжат");
            Decompress("C://for13lab/file.gz", "C://for13lab/Unarchived.txt");
            Add("Файл восстановлен");
        }

        public static void Compress(string sourceFile, string compressedFile)
        {
            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                       
                    }
                }
            }
        }

        public static void Decompress(string compressedFile, string targetFile)
        {
            // поток для чтения из сжатого файла
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetFile))
                {
                    // поток разархивации
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                       
                    }
                }
            }
        }
}
}
