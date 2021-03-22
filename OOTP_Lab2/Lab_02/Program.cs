using System;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Lab_02
{
    class Program
    {
        struct Person
        {
            private string name;

                public string Name
                {
                    set
                    {
                    name = value;
                    }
                    get
                    {
                    return name;
                    }
                 }
        }

        static void Main(string[] args)
        {
            bool flag = false;
            byte var_byte = 255;
            sbyte var_sbyte = 127;
            char var_char = 'a';
            decimal var_decimal = 3_000.5M;
            double var_double = 3_0000D;
            float var_float = 3.9239F;
            int var_int = -123;
            uint var_uint = 120039;
            long var_long = -2834;
            ulong var_ulong = 2309;
            short var_short = -3933;
            ushort var_ushort = 4949;
           
            Console.WriteLine("Типы переменных");
            Console.WriteLine(flag.GetType());
            Console.WriteLine(var_byte.GetType());
            Console.WriteLine(var_sbyte.GetType());
            Console.WriteLine(var_char.GetType());
            Console.WriteLine(var_decimal.GetType());
            Console.WriteLine(var_double.GetType());
            Console.WriteLine(var_float.GetType());
            Console.WriteLine(var_int.GetType());
            Console.WriteLine(var_uint.GetType());
            Console.WriteLine(var_long.GetType());
            Console.WriteLine(var_ulong.GetType());
            Console.WriteLine(var_short.GetType());
            Console.WriteLine(var_ushort.GetType());

            /*******************convert types**********************/
            /***implicit conversion***/
            /*1*/
            byte ba = 9;
            int ia = ba;
            /*2*/
            ushort us = 10;
            int ius = us;
            /*3*/
            sbyte sb = -4;
            short shcsbc = sb;
            /*4*/
            int ifc = 10;
            double dci = ifc;
            /*5*/
            long lcd = 1309284;
            decimal cdl = lcd;
            /*** explicit conversion***/
            short ics = 32767;
            byte icb = (byte)ics;

            int ici = 8333338;
            ics = (short)(int)ici;

            short ics_2 = 2384;
            double dcc = 9.3738;
            ici = Convert.ToInt16(ics);
            lcd = Convert.ToInt16(ici);
            cdl = Convert.ToByte(dcc);

            /*** c boxing and unboxing ***/

            int value_type_int = 10;
            object obj = value_type_int;
            int unboxing = (int)obj;

            /*** d var *///
            var boolean = true;
            var val_int = 128;
            var val_double = 435.23423;

            int? x = 7;
            Console.WriteLine(x.Value); // 7
            Console.WriteLine(x.HasValue); // 7

            System.Nullable<int> i = null;
            Console.WriteLine(i.HasValue);


            System.Nullable<Person> Names = new Person() {Name = "Uretin"};
            Console.WriteLine(Names.Value.Name);

            /*** f error retype var ***/
            var type = 1818;
            //type = 3.23123;   // error retype


            /***************  2 string ****************/
            char[] a = { 'W', 'o', 'r', 'd' };
            char[] b = { 'W', 'o', 'r', 'l', 'd' };

            Console.WriteLine(String.Equals(a, b));

            string string1 = "One can become";
            string string2 = "a writer only if";
            string string3 = "he is talented";

            string string4 = string1 + string2 + string3;
            Console.WriteLine(string4);

            Console.WriteLine(String.Concat(string1, string2, string3,"!!!"));
            Console.WriteLine(String.Join(" ", string1, string2, string3,"!!!"));

            string string5 = string4;
            Console.WriteLine(string5);

            string[] string6 = { "first=a", "second=b", "third=c" };

            foreach(string s in string6)
            {
                int position = s.IndexOf('=');
                Console.WriteLine(s.Substring(position + 1));
            }

            string string7 = "One can become a writer only if he is talented";
   
            string[] words = string7.Split(new char[] { ' ' });
            foreach(string temp in words)
            {
                Console.WriteLine(temp);
            }

            string7 = string7.Insert(4, "not ");
            Console.WriteLine(string7);

            string7 = string7.Remove(35);
            Console.WriteLine(string7);

            Console.WriteLine($"1 string {string1} 2 string {string2} 3 string {string3}");

            string stringNULL = null;
            string stringEmpty = "";

            Console.WriteLine("String has value: {0}.", TEST(string1));
            Console.WriteLine("String has value: {0}.", TEST(string2));
            Console.WriteLine("String has value: {0}.", TEST(stringNULL));
            Console.WriteLine("String has value: {0}.", TEST(stringEmpty));

            String TEST(string s)
            {
                if (String.IsNullOrEmpty(s))
                    return "null";
                else
                    return "not null";
            }

            StringBuilder string100500 = new StringBuilder("Строка $$$");

            Console.WriteLine($"Длина строки {string100500.Length}");
            Console.WriteLine($"Размер выдееленный для строки {string100500.Capacity}");

            string100500.Remove(0, 7);
            Console.WriteLine(string100500);
            string100500.Insert(0, "вначало ");
            Console.WriteLine(string100500);
            string100500.AppendFormat(" вконец");
            Console.WriteLine(string100500);
            Console.WriteLine();

            /*** 3 Arrays   ***/
            int row = 8;
            int col = 8;
            Random ran = new Random();

            int[,] arrayInt = new int [row,col];

            for (int q = 0; q < row; q++)
            {
                for (int j = 0; j < col; j++)
                {
                    arrayInt[q, j] = ran.Next(1, 1000);
                    Console.Write(String.Format("{0,-5}", arrayInt[q, j]));
                }
                Console.WriteLine();
            }

            string[] mounths = { "Sunday", "Monday", "Tuersday", "Wednesday", "Thirsday", "Friday", "Saturday" };
            Console.WriteLine("Length days of week = {0}", mounths.Length);
            Console.WriteLine("****** days ******");
            foreach (string temp in mounths)
            {
                Console.WriteLine(temp);
            }
            Console.Write("Enter num days: ");

            int index = (Int32.Parse(Console.ReadLine()) - 1);

            Console.Write("Enter name day: ");
            mounths[index] = Console.ReadLine();

            Console.WriteLine("****** New days ******");
            foreach (string temp in mounths)
            {
                Console.WriteLine(temp);
            }

            int[][] stepsArray = new int[3][];
            for (int k = 0, num = 0; k < stepsArray.Length; k++)
            {

                num = Int32.Parse(Console.ReadLine());

                stepsArray[k] = new int[num];

                for (int m = 0; m < num; m++)
                {
                    stepsArray[k][m] = Int32.Parse(Console.ReadLine());
                }
            }

            foreach (int[] rows in stepsArray)
            {
                foreach (int cell in rows)
                {
                    Console.Write(String.Format("{0,-5}", cell));
                }
                Console.WriteLine();
            }

            var array = new object[0];
            var str = "";

            /*** 4 Tuples   ***/
            Tuple<int, char> turple2 = new Tuple<int, char>(1, 'a');
            Tuple<int, char> turple3 = new Tuple<int, char>(1, 'a');

            (int, string, char, string, ulong) turple1 = (10, "jjd", 'a', "asd", 22);
            (int, string, char, string, ulong) turple4 = (10, "jjd", 'a', "asd", 22);

            Console.WriteLine(turple1.ToString());
            Console.WriteLine($"item1 = { turple1.Item1} | item3 =  {turple1.Item3} | item4 =  {turple1.Item4}");

            var(_, _, var1, _, var2) = (11,22,"sdf",3,"ABS");

            var (item1, item2, item3, item4, item5) = turple4;

            (int ret, char fot) = turple2;

            string str_s = turple1.Item2;

            if(turple1 == turple4)
                Console.WriteLine("turple1 == turple4");
            else
                Console.WriteLine("turple1 != turple4");

            /*** 5 FUNCTION LOCAL ***/
            (int, int, int, char) vls = LocalFunction(new int[] { 1, 4, 5, 2, 2 }, "name"
            Console.WriteLine(vls.ToString());
            /*** 6 checked/unchecked ***/
            fuct1();
            fuct2();

        }

        static (int, int, int, char) LocalFunction(int[] arr, string str)
        {
            Array.Sort(arr);
            int max = arr[arr.Length - 1];
            int min = arr[0];
            int sum = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                sum += arr[i];
            }
            return (max, min, sum, str[0]);
        }

        static void fuct1()
        {
            int i1 = 2147483647;
            checked
            {
               // i1++;
            };
            Console.WriteLine(checked(i1));
        }
        static void fuct2()
        {
            int i2 = 2147483647;
            unchecked
            {
                i2++;
            }
            Console.WriteLine(unchecked(i2 + 1));
        }



    }


}
