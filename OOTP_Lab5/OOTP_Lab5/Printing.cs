using System.Diagnostics;
using System;
namespace OOTP_Lab5
{
    public static class Printing
    {
        public static void callToStringForType(dynamic val)
        {
            if (val is Train)
            {
                Console.WriteLine(val.ToString());
            }
            else if (val is Express)
            {
                Console.WriteLine(val.ToString());
            }
            else if (val is Car)
            {
                Console.WriteLine(val.ToString());
            }
            else if (val is Railway)
            {
                Console.WriteLine(val.ToString());
            }
        }
        
    }
}