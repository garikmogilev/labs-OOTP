using System;
using System.Linq;
using System.Management;
using System.Threading;

namespace OOTP_Lab15
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // ******* First task ******* // ;)
            // id, имя, приоритет, время запуска, текущее состояние,
            // сколько всего времени использовал процессор
            string fill =
                "--------------------------------------------------------------------------------------------------------------";
            Console.WriteLine("{0,-30} | {1,-10} | {2,-6} | {3,-10} | {4, -23} | {4, -23}",
                "Process name", "ID process", "Prior.", "Handle", "Start time", "Proc. time");
            Console.WriteLine(fill);
            //foreach (var process in Process.GetProcesses())
            //{
            //    string user = Owner.GetProcessOwner(process.Id);
            //    if (user == "Skvortsoff") //your user name 
            //    {
            //        Console.WriteLine($"{process?.ProcessName,-30} | " +
            //                          $"{process?.Id,-10} | " +
            //                          $"{process?.BasePriority,-6} | " +
            //                          $"{process?.Handle,-10} | " +
            //                          $"{process?.StartTime,-23} | " +
            //        Console.WriteLine(fill);
            //    }
            //}
            
            // ******* Task Second ******* // 
            // info current domain
            AppDomain defaultDomain = AppDomain.CurrentDomain;
            Console.WriteLine("Information for domain: ");
            Console.WriteLine("-> Name: {0}\n-> ID: {1}\n-> Default? {2}\n-> Path: {3}\n",
                defaultDomain.FriendlyName,defaultDomain.Id,defaultDomain.IsDefaultAppDomain(),defaultDomain.BaseDirectory);
            
            Console.WriteLine("Downloading assembly:");
            var infAsm = from asm in defaultDomain.GetAssemblies()
                orderby asm.GetName().Name
                select asm;
            foreach (var a in infAsm)
                Console.WriteLine("-> Name: \t{0}\n-> Version: \t{1}", a.GetName().Name, a.GetName().Version);
            
            
            // new download domain
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationBase = @"D:\University\Labs\OOP\labs-OOTP\OOTP_Lab15\OOTP_Lab15\MyDLL.dll";
            AppDomain newDomain = AppDomain.CreateDomain("NewDomain",null,setup);
            Console.WriteLine("Information for domain: ");
            Console.WriteLine("-> Name: {0}\n-> ID: {1}\n-> Default? {2}\n-> Path: {3}\n",
                newDomain.FriendlyName,newDomain.Id,newDomain.IsDefaultAppDomain(),newDomain.BaseDirectory);
            
            Console.WriteLine("Downloading assembly:");
            var infAsm2 = from asm in newDomain.GetAssemblies()
                orderby asm.GetName().Name
                select asm;
            foreach (var a in infAsm2)
                Console.WriteLine("-> Name: \t{0}\n-> Version: \t{1}", a.GetName().Name, a.GetName().Version);
            AppDomain.Unload(newDomain);
            
            // ******* Task third ******* //

            Counter counter1 = new Counter(10,400);
            Counter counter2 = new Counter(30,100);
            Thread threadFirst = new Thread( new ParameterizedThreadStart(JobThreads.Count));
            Thread threadSecond = new Thread( new ParameterizedThreadStart(JobThreads.Count));
            
            Console.WriteLine("\nName thread: {0} | Priority: {1} | System lang: {2} | State thread: {3}",
                threadFirst.Name,threadFirst.Priority,threadFirst.CurrentCulture,threadFirst.ThreadState);
            Console.WriteLine("Thread 1 and 2 working: ");
            threadFirst.Start(counter1);
            threadSecond.Start(counter2);
            threadFirst.Join();
            threadSecond.Join();
            
            // ******* Task forth ******* //
            Counter counter3 = new Counter(10,1,200);
            Counter counter4 = new Counter(15,2,400);
            Counter counter5 = new Counter(15,1,100);
            Counter counter6 = new Counter(15,2,100);
            Thread threadThird = new Thread( new ParameterizedThreadStart(JobThreads.EvenOddWrite));
            Thread threadForth = new Thread( new ParameterizedThreadStart(JobThreads.EvenOddWrite));
            Thread threadFive = new Thread( new ParameterizedThreadStart(JobThreads.EvenOddWrite));
            Thread threadSix = new Thread( new ParameterizedThreadStart(JobThreads.EvenOddWrite));
            Thread threadSeven = new Thread(new ParameterizedThreadStart(JobThreads.EvenOddWriteLock))
                {Name = "Seven", Priority = ThreadPriority.Highest};
            Thread threadEight = new Thread( new ParameterizedThreadStart(JobThreads.EvenOddWriteLock))
                {Name = "Eight",Priority = ThreadPriority.BelowNormal};
            
            Console.WriteLine("Thread 3 and 4 working: ");
            threadThird.Start(counter3);
            threadForth.Start(counter4);
            threadThird.Join();
            threadForth.Join();
            
            Console.WriteLine("Thread 5 and 6 working: ");
            threadSix.Priority = ThreadPriority.Lowest; // if  priority Highest and equals sleep thread not in turn
            threadFive.Start(counter5);
            threadSix.Start(counter6);
            threadFive.Join();
            threadSix.Join();
            
            Console.WriteLine("Thread 7 and 8 working: ");
            threadSeven.Start(counter5);
            threadEight.Start(counter6);
            threadSeven.Join();
            threadEight.Join();
            Thread.Sleep(5000);
            TimerCallback tm = new TimerCallback(JobThreads.ClockRun);                       // set method callback
            Timer timer = new Timer(tm, null, 0, 1000);                     // new object timer

            Console.ReadLine();
        }

        public class Counter
        {
            private int y;
            private int x;
            private int time;

            public int Time
            {
                get => time;
                set => time = value;
            }

            public int X
            {
                get => x;
                set => x = value;
            }

            public int Y
            {
                get => y;
                set => y = value;
            }
            public Counter(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public Counter(int x, int y, int time)
            {
                this.y = y;
                this.x = x;
                this.time = time;
            }

            public Counter()
            {
            }
        }


        static class Owner
        {
            static public string GetProcessOwner(int processId)
        {
            string  query = "Select * From Win32_Process Where ProcessID = " + processId;
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection moCollection = moSearcher.Get();
 
            foreach (ManagementObject mo in moCollection)
            {
                string[] args = new string[] { string.Empty };
                int returnVal = Convert.ToInt32(mo.InvokeMethod("GetOwner", args));
                if (returnVal == 0)
                    return args[0];
            }
 
            return "N/A";
        }
        }
    }
}
