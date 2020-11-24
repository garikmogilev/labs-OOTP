using System;
using System.Xml.Linq;

namespace OOTP_Lab8
{
    class Program
    {
        public static XElement collection = new XElement("collection");

        static void Main(string[] args)
        {
            try
            {
                CollectionType<int> intCollection = new CollectionType<int>();
                CollectionType<string> strCollection = new CollectionType<string>();
                CollectionType<Car> carCollection = new CollectionType<Car>();
                Car car1 = new Car("gray", "white", 1330000);
                    //Car car2 = new Car("white", "gray", 2000);
                //Car car3 = new Car("red", "black", 12000);
                ((IGeneric<Car>) carCollection).add(car1);
                //((IGeneric<Car>) carCollection).add(car2);
                //((IGeneric<Car>) carCollection).add(car3);

                ((IGeneric<int>) intCollection).add(2);
                ((IGeneric<int>) intCollection).add(22);

                ((IGeneric<string>) strCollection).add("Learning ");

                XDocument xDoc = XDocument.Load("Collection.xml");
                foreach (XElement listElement in xDoc.Element("collection").Elements("object"))
                {
                    //Console.WriteLine(listElement.Attribute("type")?.Value.ToString());
                    if (listElement.Attribute("type").Value.ToString().Equals(typeof(Car).ToString()))
                    {
                        Car temp = new Car();
                        temp.Color = listElement.Element("color")?.Value.ToString();
                        temp.InterierColor = listElement.Element("inerierColor")?.Value.ToString();
                        temp.Mileage = Int32.Parse(listElement.Element("mileage")?.Value);
                        ((IGeneric<Car>) carCollection).add(temp);
                    }

                    if (listElement.Attribute("type").Value.ToString().Equals(typeof(int).ToString()))
                    {
                        ((IGeneric<Int32>) intCollection).add(Int32.Parse(listElement.Element("value").Value));
                    }

                    if (listElement.Attribute("type").Value.ToString().Equals(typeof(string).ToString()))
                    {
                        ((IGeneric<string>) strCollection).add(listElement.Element("value").Value);
                    }
                }

                ((IGeneric<int>) intCollection).display();

                ((IGeneric<int>) intCollection).remove(22);
                ((IGeneric<int>) intCollection).remove(2);
                ((IGeneric<int>) intCollection).display();

                ((IGeneric<string>) strCollection).display();

                ((IGeneric<string>) strCollection).remove("Learning ");
                ((IGeneric<string>) strCollection).display();

                ((IGeneric<Car>) carCollection).display();
                ((IGeneric<Car>) carCollection).remove(car1);
                ((IGeneric<Car>) carCollection).display();

                intCollection.WriteXml();
                strCollection.WriteXml();
                carCollection.WriteXml();
                intCollection.Save();



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, e.StackTrace, e.Source);
            }
            finally
            {
                Console.WriteLine("Data write XML");
            }
        }
    }
    
}