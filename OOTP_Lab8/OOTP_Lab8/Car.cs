using System;
using System.Runtime.CompilerServices;

namespace OOTP_Lab8
{
public class Car : IComparable<Car>
{
        private string _color;
        private string _interierColor;
        private int _mileage;
        private IComparable<Car> _comparableImplementation;

        public Car(string color = "N/A", string inerierColor = "N/A", int mileage = 0)
        {
            this._color = color;
            this._interierColor = inerierColor;
            this._mileage = mileage;
        } 

        public override string ToString()
        {
            return "#------object------#\n" +
                   "Type: " + base.ToString() + 
                   "\nColor: " + this._color + 
                   "\nColor interier: "  + this._interierColor + 
                   "\nMileage: "  + this._mileage +
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

        public string Color
        {
            get => _color;
            set => _color = value;
        }

        public string InterierColor
        {
            get => _interierColor;
            set => _interierColor = value;
        }

        public int Mileage
        {
            get => _mileage;
            set => _mileage = value;
        }
        
}

  
}