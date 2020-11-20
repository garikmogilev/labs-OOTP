using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace OOTP_Lab8
{
    public class CollectionType<T> : IGeneric<T> where T : IComparable<T>
    {
        private const  int size = 10;
        private static int index = 0;
        private T[] innerArray = new T[size];
        public static XDocument xDoc = new XDocument();
        private static List<XElement> list = new List<XElement>();
        void IGeneric<T>.add(T item)
        {
            if (index < size)
                innerArray[index++] = item;
            else
                Console.WriteLine("Collection is full");
        }

        void IGeneric<T>.remove(T item)
        {
            bool foundFailure = false;
            for (int i = 0; i < index; i++)
            {
                if (item is Car)
                {
                    Car car = new Car();
                    Car car2 = new Car();
                    car = item as Car ;
                    car2 = innerArray[i] as Car ;
                    
                    if (EqualsCar(car,car2))
                    {
                        for (int j = i; j < index; j++)
                        {
                            innerArray[j] = innerArray[j + 1];
                        }

                        index--;
                        foundFailure = true;
                    }
                }
                else
                {
                    if (innerArray[i].CompareTo(item) == 0)
                    {
                        T temp;
                        for (int j = i; j < index; j++)
                        {
                            innerArray[j] = innerArray[j + 1];
                        }

                        index--;
                        foundFailure = true;
                    }
                }
                
                
            }
            if(foundFailure)
                Console.WriteLine($"Element \"{item.ToString()}\" delete from collection");
            else
                Console.WriteLine($"Element \"{item.ToString()}\" not found in collection");
        }

        void IGeneric<T>.display()
        {
            Console.WriteLine("/***************Display***************/");
            for (var i = 0; i < index; i++)
            {
                Console.Write(innerArray[i] is Car ? $"{innerArray[i].ToString()} " : $"{innerArray[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine("/************************************/");
        }

        public void WriteXml()
        {
            for (var i = 0; i < index; i++)
            {
                
                if (innerArray[i] is Car)
                {
                    var car =  innerArray[i] as Car;
                    var temp = new XElement("object");
                    var carNameAttr = new XAttribute("type", typeof(T));
                        
                    if (car != null)
                    {
                        var carColor = new XElement("color", car.Color);
                        var colorElem = new XElement("inerierColor", car.InterierColor);
                        var mileageElem = new XElement("mileage", car.Mileage.ToString());

                        temp.Add(carNameAttr);
                        temp.Add(carColor);
                        temp.Add(colorElem);
                        temp.Add(mileageElem);
                    }

                    list.Add(temp);
                }
                else 
                {
                    var temp = new XElement("object");
                    var type = new XAttribute("type", typeof(T));
                    var value = new XElement("value",innerArray[i]);
                    temp.Add(type);
                    temp.Add(value);
                    list.Add(temp);
                }
            }
            foreach (var temp in list)
            {
                Program.collection.Add(temp);
            }
            xDoc.Add(Program.collection);
            
        }
        public void Save()
        {
            xDoc.Save("Collection.xml");
        }

        private bool EqualsCar(Car temp, Car temp2)
        {
            return temp.Color == temp2.Color
                   && temp.InterierColor == temp2.InterierColor
                   && temp.Mileage == temp2.Mileage;
        }

    }
}