using Microsoft.VisualBasic;
using System;
using System.Runtime.CompilerServices;

namespace OOTP_LAB_3
{
    class Program
    {
        public partial class Bus
        {
            private const string busDepot = "AvtoTrans";
            private string firstName;
            private string initials;
            private int numberBus;
            private int numberRoute;
            private string model;
            private int yearOfIssue;
            private int mileage;
            private readonly int ID;                    //хеш объекта
            private static int  quantityBus;            //количество автобусов            
            public void getModelToUper(ref string mod, out string result)
            {
                result = mod.ToUpper();
            }

            public int getID()
            {
                return ID;
            }

            public override string ToString()
            {
                return String.Concat(
                    "Автобус: ",quantityBus,
                    "\nПерввозчик: ",busDepot,
                    "\nИмя водителя: ",this.firstName,
                    "\nИнициалы: ",this.initials,
                    "\nНомер автобуса: ", this.numberBus,
                    "\nНомер маршрута: ", this.numberRoute,
                    "\nМарка: ", this.model,
                    "\nГод выпуска: ",this.yearOfIssue,
                    "\nПробег: ", this.mileage,
                    "\nHash: ", this.ID,"\n");
            }

            public Bus() { }
            public Bus
                (
                string name = "", 
                string init = "", 
                int numBus = 0, 
                int numRoute = 0, 
                string model = "", 
                int issue = 0, 
                int mil = 0
                )
            {
                if (name!="") { this.firstName = name;}
                if (init != "") { this.initials = init; }
                if (numBus > 0 && numBus < Int32.MaxValue) { this.numberBus = numBus;}
                if (numRoute>0 && numRoute < Int32.MaxValue) { this.numberRoute = numRoute; }
                if(model != ""){this.model = model;}
                if (issue > 0 && issue < 2020) { this.yearOfIssue = issue; }
                if (mileage > 0 && mileage < Int32.MaxValue) {  this.mileage = mil; }

                this.ID = this.GetHashCode();
                quantityBus++;
            }
            public int calculateLifeTime()
            {
                return (2020 - this.yearOfIssue);
            }
            static Bus()
            {
                quantityBus = 0;
            }
            public override bool Equals(object obj)
            {
                return Equals(base.GetHashCode(), obj.GetHashCode());
            }

        }

        public partial class  Bus
        {
            public string FirstName
            {
                get => firstName;
                set => firstName = value;
            }

            public string Initials
            {
                get => initials;
                set => initials = value;
            }

            public int NumberBus
            {
                get => numberBus;
                set => numberBus = value;
            }

            public int NumberRoute
            {
                get => numberRoute;
                set => numberRoute = value;
            }

            public string Model
            {
                get => model;
                set => model = value;
            }

            public int YearOfIssue
            {
                get => yearOfIssue;
                set => yearOfIssue = value;
            }

            public int Mileage
            {
                get => mileage;
                set => mileage = value;
            }

            public static int QuantityBus
            {
                get => quantityBus;
                set => quantityBus = value;
            }
        }
      
        static void Main(string[] args)
        {
            Bus bus1 = new Bus("Petrov", "P.V", 2201, 1, "Maz", 1990, 546574);
            Bus bus2 = new Bus("Ivanov", "I.P", 1212, 3, "SAS", 1980, 1000001);
            Bus bus3 = new Bus("Vasutin", "P.V", 2412, 3, "EK", 2000, 13198);
            Bus bus4 = new Bus("Hrevada", "P.L", 2543, 5, "Maz", 1990, 546574);
            Bus bus5 = new Bus("Inlyaps", "K.P", 1212, 2, "SAS", 1980, 1000001);
            Bus bus6 = new Bus("Muasawe", "O.V", 2412, 4, "EK", 2000, 13198);

            var busAnonyme = new { Lastname = "Hastew",initials = "Q.G", numbBus = 7478,route = 9, model = "FJH", issue = 1950, mileage = 1928379 };
            Console.WriteLine(bus3.ToString());

            Bus bus7 = new Bus();
            string model = "man";
            string modelUp;
            bus4.getModelToUper(ref model,out modelUp);

            Console.WriteLine(modelUp);

            Console.WriteLine($"bus1 = bus3 {bus1.Equals(bus3)}");
            Bus[] buses = { bus1, bus2, bus3, bus4,bus5, bus6 };

            //поиск по номеру маршрута
            Console.WriteLine("Введите номер автобуса для поиска");
                int varToSearch = 0;
            varToSearch = Int32.Parse(Console.ReadLine());
            foreach(Bus temp in buses)
            {
                if(temp.NumberRoute == varToSearch)
                {
                    Console.WriteLine("Автобус найден: ");
                    Console.WriteLine(temp.ToString());
                }
            }

            //Поиск автобуса больше заданного срока
            Console.WriteLine("Введите срок службы автобуса");
            varToSearch = Int32.Parse(Console.ReadLine());
            foreach (Bus temp in buses)
            {
                int a = temp.calculateLifeTime();
                //Console.WriteLine(a);
                if (a > varToSearch)
                {
                    Console.WriteLine("Автобус найден: ");
                    Console.WriteLine(temp.ToString());
                }
            }


        }

    }
}
