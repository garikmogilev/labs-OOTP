using System;
using System.Runtime.CompilerServices;

namespace OOTP_Lab8
{
public class Car : IComparable<Car>
{
        private string color;
        private string interier_color;
        private int mileage;
        private IComparable<Car> _comparableImplementation;

        public Car(string color = "N/A", string inerierColor = "N/A", int mileage = 0)
        {
            this.color = color;
            this.interier_color = inerierColor;
            this.mileage = mileage;
        } 

        public override string ToString()
        {
            return "#------object------#\n" +
                   "Type: " + base.ToString() + 
                   "\nColor: " + this.color + 
                   "\nColor interier: "  + this.interier_color + 
                   "\nMileage: "  + this.mileage +
                   "\n";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(Car other)
        {
            return _comparableImplementation.CompareTo(other);
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }

        public string Color()
        {
            return this.color;
        }
        public string interierColor()
        {
            return this.interier_color;
        }

        public int Mileage()
        {
            return this.mileage;
        }
}

  
}