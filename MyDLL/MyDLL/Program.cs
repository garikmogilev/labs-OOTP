

using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDLL
{
    internal class Program
    {
        public static IEnumerable<int> GetEven(List<int> list)
        {
            foreach (var elem in list)
            {
                if(elem%2==0)
                    yield return elem;
            }

        }
    }
}