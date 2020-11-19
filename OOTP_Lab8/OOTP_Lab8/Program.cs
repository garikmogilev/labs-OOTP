using System;
using System.Xml.Linq;

namespace OOTP_Lab8
{
    class Program
    {
        public static XElement collection = new XElement("collection");
        
        static void Main(string[] args)
        {

            CollectionType<int> intCollection = new CollectionType<int>();
            CollectionType<string> strCollection = new CollectionType<string>();
            CollectionType<Car> carCollection = new CollectionType<Car>();
            
            ((IGeneric<int>)intCollection).add(5);
            ((IGeneric<int>)intCollection).add(22);
            ((IGeneric<int>)intCollection).add(45);
            ((IGeneric<int>)intCollection).add(1);
            ((IGeneric<int>)intCollection).add(453);
            ((IGeneric<int>)intCollection).display();
            
            ((IGeneric<int>)intCollection).remove(22);
            ((IGeneric<int>)intCollection).remove(2);
            ((IGeneric<int>)intCollection).display();
            
            ((IGeneric<string>)strCollection).add("C");
            ((IGeneric<string>)strCollection).add("#");
            ((IGeneric<string>)strCollection).add(" ");
            ((IGeneric<string>)strCollection).add("not");
            ((IGeneric<string>)strCollection).add(" ");
            ((IGeneric<string>)strCollection).add("interesting");
            ((IGeneric<string>)strCollection).display();
            
            ((IGeneric<string>)strCollection).remove("not");
            ((IGeneric<string>)strCollection).display();
            
            Car car1 = new Car("gray","white",100000);
            Car car2 = new Car("pink","yellow",22000);
            Car car3 = new Car("red","gray",77000);

            
            ((IGeneric<Car>)carCollection).add(car1);
            ((IGeneric<Car>)carCollection).add(car2);
            ((IGeneric<Car>)carCollection).add(car3);
            ((IGeneric<Car>)carCollection).display();
            
            //((IGeneric<Car>)carCollection).remove(car1);
            ((IGeneric<Car>)carCollection).display();
            intCollection.writeXML();
            strCollection.writeXML();
            carCollection.writeXML();
            intCollection.Save();
            strCollection.Save();
            carCollection.Save();

            XDocument xDoc = XDocument.Load("Collection.xml");
            foreach (XElement phoneElement in xDoc.Element("collection").Elements("object"))
            {
                Console.WriteLine(phoneElement.Attribute("type").Value.ToString());
                if (phoneElement.Attribute("type").Value.ToString().Equals(typeof(Car).ToString()))
                {
                    Console.WriteLine("!!!");
                }
            }

            Console.ReadLine();

        }
    }
    
}