using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace OOTPLab4
{
    internal static class Program
    {
        public static void Main()
        {
            MyList<int> a = new MyList<int> {1, 2, 3, 4, 5, 6, 7, 8};
            MyList<int> b = new MyList<int> {6, 7, 8, 9, 10 ,11 ,12 ,13};
            a.owner.SetAuthorAndCompany("Igor","Skvortsof");
            b.owner.SetAuthorAndCompany("Vasya", "Petrov");
            a.date = DateTime.Now;
            b.date = DateTime.Now;
         
            Console.WriteLine(a!=b);                                        // перегрузка !=
            Console.WriteLine(a==b);                                        // перегрузка ==
            Console.WriteLine(a ? "отсортирован": "не отсортирован");       // перегрузка true/false
            
            a = a + (a.Count + 1);                                          // перегрузка List<T> + item
            foreach (var item in a)
                Console.Write(item);
            Console.WriteLine();
            
            a--;                                                            // перегрузка --
            foreach (var item in a)
                Console.Write(item);
            Console.WriteLine();
            
            a--;
            foreach (var item in a)
                Console.Write(item);
            
            Console.WriteLine();
            
            Console.WriteLine(a.date);
            Console.WriteLine($"{a.owner.Autor} {a.owner.Company}");
            
            Console.WriteLine(b.date);
            Console.WriteLine($"{b.owner.Autor} {b.owner.Company}");

            Console.WriteLine(a.Summ());
            Console.WriteLine(a.Count());
        }
    }
}
 
