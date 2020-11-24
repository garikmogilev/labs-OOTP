using System;

namespace OOTP_Lab9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Account acc = new Account(100);
            acc.Notify += DisplayMessage;                        // Добавляем обработчик для события Notify
            acc.Put(20);                                    // добавляем на счет 20
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            acc.Take(70);                                   // пытаемся снять со счета 70
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            acc.Take(180);                                  // пытаемся снять со счета 180
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
        }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}