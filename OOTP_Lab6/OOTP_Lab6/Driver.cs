using System.Diagnostics;
using System.Runtime.Serialization.Formatters;

namespace OOTP_Lab6
{
    public class Driver
    {
        private int age;
        private double alcohol;
        private bool driverlicense;

        public void Driverlicense(bool driverLicense)
        {
            this.driverlicense = driverLicense;
            Debug.Assert(this.driverlicense);
            Debug.Close();
        }

        public int Age
        {
            set
            {
                if (value >= 18)
                {
                    age = value;
                }
                else
                {
                    
                    throw new percentAlcohol("За руль строго с 18 лет!");
                }
            }
            get
            {
                return age;
            }
        }

        public double Alcohol
        {
            set
            {
                if (value < 0.8)
                {
                    alcohol= value;
                }
                else
                {
                    throw new percentAlcohol("Вы пьяны в хлам, вам нельзя за руль");
                }
            }
            get
            {
                return alcohol;
            }
        }
    }
}