using System;
using System.Collections.Generic;
using System.Text;

namespace OOTP_Lab6
{
    public partial class Car : ICloneable, IComparable
    {
        public override string ToString()
        {
            return "Type: " + base.ToString() +
                   "\n" + getColor(this.color) +
                   "\nColor interier: " + this.inerier_color +
                   "\nMileage: " + this.mileage +
                   "\nType fuel: " + engine.Fuel +
                   "\nPower: " + engine.Power +
                   "\nSpeed: " + this.speed +
                   "\nPrice: " + this.cost +
                   "\n";
        }
        public int getCost()
        {
            return this.cost;
        }
        public int getSpeed()
        {
            return this.speed;
        }
        private string getColor(colors color)
        {
            switch (color)
            {
                case colors.red:
                    return "red";
                case colors.blue:
                    return "blue";
                case colors.green:
                    return "green";
                case colors.yellow:
                    return "yellow";
                default:
                    return "undefined";

            }

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }
        int IComparable.CompareTo(object car)
        {
            Car c = car as Car;
            if (c != null)
            {
                return this.speed.CompareTo(c.speed);
            }
            else
            {
                throw new Exception("Ошибка в типе объектов");
            }
        }

        public object Clone()
        {
            return new Car { color = this.color, engine = this.engine, inerier_color = this.inerier_color, mileage = this.mileage, other = this.other };
        }

    }
}
