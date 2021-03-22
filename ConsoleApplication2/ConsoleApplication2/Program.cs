using System;
using System.Net.NetworkInformation;
using System.Reflection;

namespace ConsoleApplication2
{
    internal abstract class Creator
    {
        public abstract ITransport FactoryMethod();

        public string SomeOperations()
        {
            var transport = FactoryMethod();
            var result = "Creator object " + transport.Operation();

            return result;
        }
    }

    internal class CarCreator : Creator
    {
        public override ITransport FactoryMethod()
        {
            return new Car();
        }
    }
    internal class AirplaneCreator:Creator
    {
        public override ITransport FactoryMethod()
        {
            return new Airplane();
        }
    }

    public interface ITransport
    {
        string Operation();
    }

    class Car:ITransport
    {
        public string Operation()
        {
            return "Car created";
        }
    }

    internal class Airplane:ITransport
    {
        public string Operation()
        {
            return "Airplane created";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Created Car");
            ClientCode(new AirplaneCreator());
            ClientCode(new CarCreator());
        }

        public void ClientCode(Creator creator)
        {
            Console.WriteLine(creator.SomeOperations());
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}