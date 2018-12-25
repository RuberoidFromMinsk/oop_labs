using System;
using System.IO;

namespace lab13
{
    class Log
    {
        private System.IO.FileInfo file;
        private System.IO.FileInfo file2;

        public Log()
        {
            file = new System.IO.FileInfo("C://for13lab//LOGfile.txt");
            file2 = new System.IO.FileInfo("C://for13lab//test.txt");
        }
        public void Add(string a)
        {
            using (StreamWriter writer = new StreamWriter(file.ToString(), true, System.Text.Encoding.Default))
            {
                writer.WriteLine(DateTime.Now + " - " + a);
            }
        }
        public void Read()
        {
            using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
            {
                int a = 0;
                while (true)
                {
                    if (reader.EndOfStream)
                    {
                        break;
                    }
                    Console.WriteLine(reader.ReadLine());
                    a++;
                }
                Console.WriteLine("Кол.-во записей в файле: " + a);
            }
        }
        public void DeleteTime()
        {
            using (StreamWriter fs = new StreamWriter(file2.ToString(), false, System.Text.Encoding.Default))
            {
                string pl = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString() + " " + DateTime.Now.Hour.ToString() + ":";

                string str = "";
                Console.WriteLine(pl);
                using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
                {
                    while (true)
                    {
                        if (reader.EndOfStream)
                        {
                            break;
                        }
                        srt = reader.ReadLine();
                        if (str.Contains(pl))
                        {
                            fs.WriteLine(str);
                        }
                    }
                }
            }
            file.Delete();
            file2.MoveTo("C://for13lab//LOGfile.txt");
        }
        public void Search()
        {
            Console.WriteLine("Поиск: \n1. Указать дату.\n2. Указать ключевое слово.");
            string a, b;
            int r;
            r = int.Parse(Console.ReadLine());
            switch (r)
            {
                case 1:
                    using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
                    {
                        Console.WriteLine("Укажите дату в формате 00.00.0000: ");
                        a = Console.ReadLine();
                        while (true)
                        {
                            if (reader.EndOfStream)
                            {
                                break;
                            }
                            if (reader.ReadLine().Contains(a))
                            {
                                Console.WriteLine(reader.ReadLine());
                            }
                        }
                    }
                    break;
                case 2:
                    using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
                    {
                        Console.WriteLine("Введите ключевое слово: ");
                        a = Console.ReadLine();
                        while (true)
                        {
                            if (reader.EndOfStream)
                            {
                                break;
                            }
                            if (reader.ReadLine().Contains(a))
                            {
                                Console.WriteLine(reader.ReadLine());
                            }
                        }
                    }
                    break;
            }

        }

    }
}
