using System;
using System.IO;
using System.Net.Configuration;
using System.Threading;

namespace OOTP_Lab15
{
    public static class JobThreads
    {
        private static StreamWriter file = new StreamWriter("out.txt");
        private static StreamWriter file2 = new StreamWriter("out2.txt");
        private static object locker = new object();
        private static DateTime date = DateTime.Now;

        public static void Count(object obj)
        {
            Program.Counter x = new Program.Counter();
            x = (Program.Counter) obj;
            for (int i = 1;i <= x.X; i++)
            {
                Console.Write($"{i,-5}");
                file.Write($"{i,-5}");
                if (i % 20 == 0)
                {
                    Console.WriteLine();
                    file.WriteLine();
                }
                Thread.Sleep(x.Y);
            }
            file.WriteLine();
            Console.WriteLine();
            file.Flush();
        }
        
        public static void EvenOddWrite(object obj)
        {
            Program.Counter x = new Program.Counter();
            x = (Program.Counter) obj;
            for (int i = x.Y; i <= x.X; i+=2)
            {
                Console.Write($"{i,-5}");
                file2.Write($"{i,-5}");
                Thread.Sleep(x.Time);
            }
            file2.WriteLine();
            Console.WriteLine();
            file2.Flush();
        }
        
        public static void EvenOddWriteLock(object obj)
        {
            lock (locker)
            {
                Program.Counter x = new Program.Counter();
                x = (Program.Counter) obj;
                for (int i = x.Y; i <= x.X; i += 2)
                {
                    Console.Write($"{i,-5}");
                    file2.Write($"{i,-5}");
                    Thread.Sleep(x.Time);
                }

                file2.WriteLine();
                Console.WriteLine();
                file2.Flush();
            }
        }

        public static void ClockRun(object obj)
        {
            date = DateTime.Now;
            Console.Clear();
            Console.Write("{0} : {1} : {2}",date.Hour,date.Minute,date.Second);
            
        }
        
    }
}