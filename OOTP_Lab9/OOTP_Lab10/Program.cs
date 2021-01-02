using System;

namespace OOTP_Lab10
{
    internal class Program
    {
       
            
        public static void Main(string[] args)
        {
                var user = new User("Valera");
                var str = "We    don’t need no education,    we don’t need no thought control.";
                user.EvenAction += () => Console.Write("User \"");
                user.EvenAction += () => Console.WriteLine($"{user.Name}\" working");
                user.Work();

                user.DelegateFunc += user.Upgrade;
                user.DelegateFunc += user.CurrentVersion;
                user.DelegateAction = user.SystemMassage;
                user.DelegateFunc(2);
                user.DelegateFunc(3);

                LineHandler lineHandler = new LineHandler();
                lineHandler.Display($"\n{str}");
                
                lineHandler.EventSystem += lineHandler.Display;
                lineHandler.FuncStr = lineHandler.RemovingPunctuationSymbol;
                lineHandler.FuncStr += lineHandler.StringToUpperCase;
                lineHandler.FuncStr += lineHandler.StringReplaceToSymbol;
                lineHandler.FuncStr += lineHandler.RemovingExtraSpaces;
                
                lineHandler.FuncStr(str);

        }
    }
    
}