using System;
using System.Linq;
using System.Net;

//internal
namespace OOTP_Lab6
{
    public enum colors { undef, red, green, blue, yellow };
    public struct properties{                                       
        public int wheelradius { get; set; } //=0; Ошибка
        public int clearance { get; set; }
        public properties(int clearance,int wheelradius)
        {
            this.clearance = clearance;
            this.wheelradius = wheelradius;
        }
        public void display()
        {
            Console.WriteLine("Дорожный просвет: {0}", this.clearance);
            Console.WriteLine("Диаметр дисков: {0} дюймов\n", this.wheelradius);
        }
    }
    class Print : print, printSecond
    {
        public void msgHello()
        {
            Console.WriteLine("hello");
            
        }

        public void callMsgHelloI()
        {
            base.msgHello();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Car opel = new Car("white", 65000, 110, "petrol", colors.red, 17, 15, 10000, 130);
                Car volkswagen = new Car("white", 1000, 70, "diesel", colors.green, 17, 10, 18800, 95);
                Car renault = new Car("gray", 99000, 1300, "diesel", colors.yellow, 17, 10, 12500, 135);
                Car ford = new Car();
                Train train = new Train("blue", "green", 5000, "diesel", true);
                Express trainexp = new Express("gray", "red", 5000, "nitrogen", true);
                Railway railway = new Railway("orange", "gray");

                //Printing.callToStringForType(opel); 
                //opel.other.display();

                //Printing.callToStringForType(volkswagen);
                //Printing.callToStringForType(train);
                //Printing.callToStringForType(trainexp);

                //opel.radioOn();
                //opel.radioOff();

                //Print printmsg = new Print();
                //printmsg.msgHello();
                //printmsg.callMsgHelloI();
                //Console.WriteLine("--------------------------------------------");

                Cars cars = new Cars();
                cars.Add(opel);
                cars.Add(volkswagen);
                cars.Add(renault);
                //cars.Display();
                cars.Sort();
                //cars.Display();
                //Console.WriteLine(cars.SummAllCars());
                //Console.WriteLine("Введите максимальную и минимальную скорость");
                //0cars.SearchSpeed(Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()));

                int a = 10;
                //a = a / 0;
                int[] z = {10, 1, 4, 2, 9, 0};
                
                Car bmw = null;
                //bmw.getCost();
                
                //int x = z[10];
                
                forThrow mul = new forThrow();
                mul.Mul(z[1], z[5]);
                
                Driver driver = new Driver();
                //driver.Age = 17;
                //driver.Alcohol = 1.0;
                //driver.Driverlicense(false);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.InnerException);
                Console.WriteLine("Неверный индекс");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.InnerException);
                Console.WriteLine("Деление на ноль");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.InnerException);
                Console.WriteLine("Объект равен null!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.InnerException);
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Конец программы");
            }
            
        }
        
        
    }
}
