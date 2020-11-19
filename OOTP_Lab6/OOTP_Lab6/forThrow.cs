using System;
namespace OOTP_Lab6
{
    public class forThrow
    {
        public void Mul(int x, int y)
        {
            try
            {
                y = x / y;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Ошибка в методе valMulZero");
                throw;
            }
        }
    }
}