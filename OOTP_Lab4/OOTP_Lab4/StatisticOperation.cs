using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab4
{
    public static class StatisticOperation
    {
        private static int summ;
        private static int counter;

        public static int Summ(this MyList<int> a)
        {
            foreach (var item in a)
            {
                summ = summ + item;
            }
          
            return summ ;
        }

        public static int Counter(this MyList<int> a)
        {
            foreach (var item in a)
                counter++;
            return counter;
        }
        
        public static string findMinimalSizeWord(this string str)
        {
            string[] words = str.Split(' ');
            string strOut = words.Min();
            
            return strOut;
        }
        
        public static string findMaxSizeWord(this string str)
        {
            string[] words = str.Split(' ');
            string strOut = words.Max();
            return strOut;
        }
        
        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i<str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
    }
}