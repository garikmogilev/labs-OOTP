namespace OOTP_Lab5
{
    public class Engine
    {
        private int power;
        private string fuel;

        public int Power
        {
            get => power;
            set => power = value;
        }

        public string Fuel
        {
            get => fuel;
            set => fuel = value;
        }
        public Engine()
        {
        }
        public Engine(int power, string fuel)
        {
            this.power = power;
            this.fuel = fuel;
        }
    }
}