using System;
using System.ComponentModel.Design;

namespace OOTP_Lab6
{
    public partial class Car : IRadio
    {
        private string inerier_color;
        private int mileage;
        private Engine engine;
        private colors color;
        public properties other;
        private int cost;
        private int speed;

        public void radioOn()
        {
           Console.WriteLine("Radio on");
        }

        public void radioOff()
        {
            Console.WriteLine("Radio off");
        }
        public Car(
            string inerierColor = "N/A",
            int mileage = 0,
            int power = 0,
            string fuel = null,
            colors color = colors.undef,
            int wheelradius = 0,
            int clearance = 0,
            int price = 0,
            int speed = 0
            )
        {
            this.inerier_color = inerierColor;
            this.mileage = mileage;
            this.engine = new Engine(power,fuel);
            this.color = color;
            other.clearance = clearance;
            other.wheelradius = wheelradius;
            this.speed = speed;
            this.cost = price;
        }

       
        
    }

   sealed class Train : PremiumFeatures
    {
        private string color;
        private string inerier_color;
        private Engine engine;
        
        public Train(string color = "N/A", string inerierColor = "N/A", int power = 0, string fuel = null, bool navi = false)
              :base(navi)
        {
            this.color = color;
            this.inerier_color = inerierColor;
            this.engine = new Engine(power,fuel);
        }
        
        public override string ToString()
        {
            return "Type: " + base.ToString() + 
                   "\nColor: " + this.color + 
                   "\nColor interier: "  + this.inerier_color + 
                   "\nType fuel: " + engine.Fuel + 
                   "\nPower: " + engine.Power + 
                   "\n";
        }
    }
   sealed class Express : PremiumFeatures
   {
       private string color;
       private string inerier_color;
       private Engine engine;
        
       public Express(string color = "N/A", string inerierColor = "N/A", int power = 0, string fuel = null, bool navi = false)
           :base(navi)
       {
           this.color = color;
           this.inerier_color = inerierColor;
           this.engine = new Engine(power,fuel);
       }

       public override void setOptions(string addOptons)
       {
           Console.WriteLine("Данные не были записаны:");
           Console.WriteLine(addOptons);
       }
        
       public override string ToString()
       {
           return "Type: " + base.ToString() +
                  "\nColor: " + this.color + 
                  "\nColor interier: "  + this.inerier_color + 
                  "\nType fuel: " + engine.Fuel + 
                  "\nPower: " + engine.Power + 
                  "\n";
       }
   }

   sealed public class Railway
   {
       private string color;
       private string inerier_color;

       public Railway(string color = "N/A", string inerierColor = "N/A")
       {
           this.color = color;
           this.inerier_color = inerierColor;
           
       }

       public override string ToString()
       {
           return "Type: " + base.ToString() +
                  "\nColor: " + this.color + 
                  "\nColor interier: "  + this.inerier_color +
                  "\n";
       }
   }
   
   }