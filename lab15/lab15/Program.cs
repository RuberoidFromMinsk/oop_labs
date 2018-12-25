using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;

namespace lab15
{
    class Program
    {
        static AutoResetEvent waitHandler = new AutoResetEvent(false);
        private static ManualResetEvent mr = new ManualResetEvent(false);
        static int w = 0;

        static void Main(string[] args)
        {
            //работаем с процессами
            foreach (Process pr in Process.GetProcesses())
            {
                Console.WriteLine("Имя процесса: " + pr.ProcessName + " Приоритет: " + pr.BasePriority + " Состояние: " + pr.Responding + " Использует физ. памяти: " + pr.WorkingSet64);
            }
            //исследуем текущий домен
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("Name: " + domain.FriendlyName);
            Console.WriteLine("Directory: " + domain.BaseDirectory);
            foreach (Assembly a in domain.GetAssemblies())
            {
                Console.WriteLine(a.GetName().Name);
            }
            //создаем домен, загружаем туда сборку, выгружаем домен
            AppDomain secdomain = AppDomain.CreateDomain("Second Domain");
            secdomain.Load(new AssemblyName("lab15"));
            Console.WriteLine("Name: " + secdomain.FriendlyName);
            foreach (Assembly a in secdomain.GetAssemblies())
            {
                Console.WriteLine(a.GetName().Name);
            }
            AppDomain.Unload(secdomain);

            //Task3
            Console.WriteLine("\nПоиск простых чисел");
            Console.WriteLine("Введите n: ");
            Thread myThread = new Thread(new ParameterizedThreadStart(isSimple));
            int n = int.Parse(Console.ReadLine());
            myThread.Start(n);
            Thread.Sleep(3000);

            //Task4
            Console.WriteLine("\nВведите x: ");
            int x = int.Parse(Console.ReadLine());
            Thread first = new Thread(new ParameterizedThreadStart(Chet));
            Thread second = new Thread(new ParameterizedThreadStart(Nechet));
            //second.Priority = ThreadPriority.Highest;
            Console.WriteLine(first.Priority);
            Console.WriteLine(second.Priority);
            first.Start(x);
            second.Start(x);
            
            //Task5
            Console.WriteLine("\nВведите количество секунд(таймер): ");
            int ch = int.Parse(Console.ReadLine());
            int time = 0;
            TimerCallback tm = new TimerCallback(TimerSec); // метод обратного вызова
            Timer tmr = new Timer(tm, ch, 500, 1000);
            Thread.Sleep(ch * 1000);
            tmr.Dispose();
            Console.ReadKey();
        }

        //Task5
        public static void TimerSec(object obj)
        {
            w++;
            int x = (int)obj;
            Console.WriteLine("Таймер: {0}", w);
            if (w == x)
            {
                Console.WriteLine("Time's up!");
             
            }
        }

        //Task4
        public static void Chet(object x)
        {
            
            FileInfo file = new FileInfo("chetnechet.txt");
            int n = (int)x;
            for (int i = 1; i <= n; i++)
            {
                if ((i % 2) == 0)
                {
                    Console.WriteLine("First Thread: " + i);
                    Thread.Sleep(300);

                    using (StreamWriter writer = new StreamWriter(file.ToString(), true, System.Text.Encoding.Default))
                    {
                        writer.Write(i + " ");
                    }
                    
                }
            }
            waitHandler.Set();
          
        }
        public static void Nechet(object x)
        {
           waitHandler.WaitOne();
            
            FileInfo file = new FileInfo("chetnechet.txt");
            int n = (int)x;
            for (int i = 1; i <= n; i++)
            {
                if ((i % 2) != 0)
                {
                    Console.WriteLine("Second Thread: " + i);
                    Thread.Sleep(500);
                    using (StreamWriter writer = new StreamWriter(file.ToString(), true, System.Text.Encoding.Default))
                    {
                        writer.Write(i + " ");
                    }
                }

            }
       
        }

        //Task3
        public static void isSimple(object x)
        {
            FileInfo file = new FileInfo("simple.txt");
            int N = (int)x;
            //чтобы убедится простое число или нет достаточно проверить не делится ли число на числа до его половины
            for(int j = 2; j <= N; j++)
            {
                if(isSimpleCheck(j))
                {
                    Console.WriteLine("myThread says: " + j);
                    using (StreamWriter writer = new StreamWriter(file.ToString(), true, System.Text.Encoding.Default))
                    {
                        writer.Write(j + " ");
                    }
                    Thread.Sleep(200);
                }
            }
        }

        public static bool isSimpleCheck(int N)
        {
            for (int i = 2; i <= (int)(N / 2); i++)
            {
                if (N % i == 0)
                    return false;
            }
            return true;
        }
    }
}