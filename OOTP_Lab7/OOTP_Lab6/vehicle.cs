using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOTP_Lab6
{
    abstract class Venicle
    {
        protected List<Car> cars = new List<Car>();
       
        public void Add(Car car)
        {
            this.cars.Add(car);
        }
        public void Remove(Car car)
        {
            cars.Remove(car);
        }

        public void Display()
        {
            for(int i = 0; i < cars.Count();i++)
            {
                Console.WriteLine(cars.ElementAt(i).ToString());
            }
        }
        
    }
    internal class Cars : Venicle
    {
        public void SearchSpeed(int minspeed, int maxspeed)
        {
            for (int i = 0; i < cars.Count(); i++)
            {

                if (cars.ElementAt(i).getSpeed() > minspeed && maxspeed > cars.ElementAt(i).getSpeed())
                {
                    Console.WriteLine("Нужный авто по скорости :");
                    Console.WriteLine(cars.ElementAt(i).ToString());
                }

            }
        }

        public int SummAllCars()
        {
            int summ = 0;
            for (int i = 0; i < cars.Count(); i++)
            {
                summ += cars.ElementAt(i).getCost();
            }
            return summ;
        }
        public void Sort()
        {
            cars.Sort();
        }
    }
  

}



