using System;
using System.Collections.Generic;
using System.Linq;

namespace OOTP_Lab11
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //>>>>>>>>>> task 1
            string[] months =
            {
                "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
                "November", "December"
            };
            var select4 = from month in months where month.Length == 4 select month;
            Console.Write("Months length == 4 : ");
            foreach (var variable in select4)
            {
                Console.Write(variable);
                Console.Write(" ");
            }

            Console.WriteLine();

            string[] winsummer = {"December", "January", "February", "June", "July", "August"};
            var selectWinSum = from s in months where winsummer.Contains(s) select s;
            Console.Write("Months summer and winter: ");
            foreach (var variable in selectWinSum)
            {
                Console.Write(variable);
                Console.Write(" ");
            }

            Console.WriteLine();

            var monthOrderBy = from s1 in months orderby s1 select s1;
            Console.Write("Months sort alphabet : ");
            foreach (var variable in monthOrderBy)
            {
                Console.Write(variable);
                Console.Write(" ");
            }

            Console.WriteLine();

            var selectMotnhU4 = from month1 in months where month1.Contains("u") && month1.Length >= 4 select month1;
            Console.Write("Months in symbol 'u' and length == 4 : ");
            foreach (var variable in selectMotnhU4)
            {
                Console.Write(variable);
                Console.Write(" ");
            }

            Console.WriteLine();
            //>>>>>>>>>> task 2
            Train train1 = new Train("Lida-Minsk", "Lida", 12, 220, 12, 23);
            Train train2 = new Train("Brest-Gomel", "Brest", 1, 324, 10, 21);
            Train train3 = new Train("Vitebsk-Polotsk", "Vitebsk", 31, 222, 18, 12);
            Train train4 = new Train("Minsk-Brest", "Minsk", 15, 444, 21, 45);
            Train train5 = new Train("Mir-Minsk", "Minsk", 22, 432, 6, 0);
            Train train6 = new Train("Bobruysk-Osipovichi", "Osipovichi", 1, 453, 17, 24);
            Train train7 = new Train("Minsk-Smorgon", "Smorgon", 1, 675, 16, 33);
            Train train8 = new Train("Smorgon-Gomel", "Brest", 1, 123, 13, 9);

            List<Train> trains = new List<Train>() {train1, train2, train3, train4, train5, train6, train7, train8};

            Train train9 = new Train("Bobruysk-Osipovichi", "Osipovichi", 1, 453, 17, 24);
            Train train10 = new Train("Minsk-Smorgon", "Smorgon", 2, 675, 16, 33);

            List<Train> trains2 = new List<Train>() {train9, train10};

            //>>>>>>>>>> task 3
            var trainsDeporture = from train in trains where train.Destination.Contains("Minsk") select train;
            Console.Write("List distanation to Minsk : ");
            foreach (var train in trainsDeporture)
            {
                Console.Write(train.Nametrain);
                Console.Write(" ");
            }

            Console.WriteLine();

            var trainsDeportureDay = from train in trains
                where train.Destination.Contains("Minsk") && train.Depurtureday > 15
                select train;
            Console.Write("List distanation to Minsk and depurture day > 15 : ");
            foreach (var train in trainsDeportureDay)
            {
                Console.Write(train.Nametrain);
                Console.Write(" ");
            }

            Console.WriteLine();

            var trainsnumberofseatsmax = (from train in trains select train.Numberofseats).Max();
            Console.Write("List distanation max number of seats : ");
            Console.WriteLine(trainsnumberofseatsmax);
            Console.WriteLine();

            var trainlastfive = trains.Skip(3).Take(5);
            Console.Write("List five trains last : ");
            foreach (var train in trainlastfive)
            {
                Console.Write(train.Nametrain);
                Console.Write(" ");
            }

            Console.WriteLine();

            var trainsorderby = from train in trains orderby train9.Nametrain select train9;
            Console.Write("List five trains last : ");
            foreach (var train in trainsorderby)
            {
                Console.Write(train.Nametrain);
                Console.Write(" ");
            }

            Console.WriteLine();

            //>>>>>>>>>> task 4
            var trainnuwosseats200 = from train in trains where train.Numberofseats >= 200 select train;
            Console.Write("Trains of seats more 200 : ");
            foreach (var train in trainnuwosseats200)
            {
                Console.Write($"{train.Nametrain} ({train.Numberofseats})");
                Console.Write(" ");
            }

            Console.WriteLine();

            var trainproection = from train in trains select new {train.Nametrain, train.Depurtureday};
            Console.Write("Objects of method proection : ");
            foreach (var train in trainproection)
            {
                Console.Write($"{train.Nametrain} ({train.Depurtureday})");
                Console.Write(" ");
            }

            int destination;
            Console.WriteLine();

            var trainorderbydesc = (from train in trains orderby train.Nametrain descending select train);
            Console.Write("Train sort desc : ");
            foreach (var train in trainorderbydesc)
            {
                Console.Write($"{train.Nametrain}");
                Console.Write(" ");
            }

            Console.WriteLine();

            var countSeats = trains.Average(n => n._numberofseats);
            Console.WriteLine(countSeats);
            
            var Trainsfivemethodss = from train in trains.Skip(2)
                where train.Numberofseats >= 200
                where train.Nametrain.StartsWith("M")
                orderby train.Nametrain descending select train;
            
            Console.Write("Тrain : ");
            foreach (var train in Trainsfivemethodss)
            {
                Console.Write($"{train.Nametrain}");
                Console.Write(" ");
            }
            //>>>>>>>>>>>>>>>>>>5
            var trainJoin = from s in trains
                join m in trains2 on s.Depurtureday equals m.Depurtureday
                select new {Name = s.Nametrain, Saets = s.Numberofseats};
            Console.Write("Trains join trains and trains2 : ");
            foreach (var train in trainJoin)
            {
                Console.Write($"{train.Name} {train.Saets}");
                Console.Write(" ");
            }
        }
    }
}