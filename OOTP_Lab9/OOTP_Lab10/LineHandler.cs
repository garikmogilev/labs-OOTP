using System;
using System.Text.RegularExpressions;

namespace OOTP_Lab10
{
    public class LineHandler
    {
        public Func<string, string> FuncStr;
        public event Action<string> EventSystem;
        public string RemovingPunctuationSymbol(string str)
        {
            
            var temp = Regex.Replace(str, "[-.?!)(,:]", "");
            
            EventSystem?.Invoke(temp);
            return temp;
        }
        public string StringToUpperCase(string str)
        {

            var temp = str.ToUpper();
            
            EventSystem?.Invoke(temp);
            return temp;
        }
        public string StringReplaceToSymbol(string str)
        {

            var temp = str.Replace('e', 'E');
            
            EventSystem?.Invoke(temp);
            return temp;
        }
        public string RemovingExtraSpaces(string str)
        {
            Regex regex = new Regex(@"\s+");
            var temp = regex.Replace(str, " ");
            EventSystem?.Invoke(temp);
            return temp;
        }
        
        public Action<string> Display = Console.WriteLine;

    }
}