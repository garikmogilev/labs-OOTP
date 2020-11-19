using System;

namespace OOTP_Lab5
{
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
            Car opel = new Car("white", "black", 65000, 110, "petrol");
            Car volkswagen = new Car();
            Car ford = new Car();
            Train train = new Train("blue", "green", 5000,"diesel",true);
            Express trainexp = new Express("gray", "red", 5000,"nitrogen",true);
            Railway railway = new Railway("orange","gray");
            
            Printing.callToStringForType(opel);
            Printing.callToStringForType(train);
            Printing.callToStringForType(trainexp);

            opel.radioOn();
            opel.radioOff();

            Print printmsg = new Print();
            printmsg.msgHello();
            printmsg.callMsgHelloI();
            
        }
        
        
    }
}
