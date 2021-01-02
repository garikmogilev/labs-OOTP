using System;

namespace OOTP_Lab12.Properties
{
    public class Car : IControlCar
    {
        private int _speed;
        private string _model;

        public int Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public string Model
        {
            get => _model;
            set => _model = value;
        }
        public Car()
        {
        }
        public Car(int speed, string model)
        {
            _speed = speed;
            _model = model;
        }

        public bool CheckSpeed(Random random)
        {
            return random.Next() > 60 ? true : false;
        }

        void Display()
        {
            Console.WriteLine(_speed);
            Console.WriteLine(_model);
        }

        public int controlAgeDrier(int age)
        {
            throw new NotImplementedException();
        }
    }
}