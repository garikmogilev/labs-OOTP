using System;
using System.IO;
using System.Xml;

namespace OOTP_Lab13
{
    static class Log
    {
        private static string pathstr = "..//..//log.txt";
        static StreamWriter outFile = new StreamWriter(pathstr, true,System.Text.Encoding.Default);

        public static void WriteInfo()
        {
            string time = "Time: \n";
            outFile.Write(time);
            outFile.Write((DateTime.Now.Hour).ToString());
            outFile.Write("\n");
            outFile.Write((DateTime.Now.Minute).ToString());
            outFile.Write("\n");
            
        }
        public static void Write(string str)
        {
            outFile.WriteLine(str);
        }

        public static void Read()
        {
            string buffer = "";
            string[] s = File.ReadAllLines(pathstr);
            //for (int i = 0; i < s.Length; i++)
            // {
            //    Console.WriteLine(s[i]);
            //}
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == "Time: ")
                    if (Int32.Parse(s[i + 1]) >= DateTime.Now.Hour - 1)
                    {
                        i++;
                        for (; i < s.Length && s[i] != "Time: "; i++)
                        {
                            buffer += s[i];
                        }
                    }
                //Log.Write(buffer);
                Console.WriteLine(buffer);
            }
        }


        public static void CloseFile(){
            outFile.Close();
        }
    }
}