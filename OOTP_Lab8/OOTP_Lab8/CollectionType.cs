using System;
using System.Collections.Generic;
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
                    if (innerArray[i].GetHashCode() == item.GetHashCode())
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
            for (int i = 0; i < index; i++)
            {
                if(innerArray[i] is Car)
                    Console.Write($"{innerArray[i].ToString()} ");
                else
                    Console.Write($"{innerArray[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine("/************************************/");
        }

        public void writeXML()
        {
            for (int i = 0; i < index; i++)
            {
                
                if (innerArray[i] is Car)
                {
                    Car car =  innerArray[i] as Car;
                    XElement temp = new XElement("object");
                    XAttribute carNameAttr = new XAttribute("type", typeof(T));
                    XElement carColor = new XElement("color", car.Color());
                    XElement colorElem = new XElement("inerierColor", car.interierColor());
                    XElement mileageElem = new XElement("mileage", car.Mileage().ToString());

                    temp.Add(carNameAttr);
                    temp.Add(carColor);
                    temp.Add(colorElem);
                    temp.Add(mileageElem);
                    list.Add(temp);
                }
                else 
                {
                    XElement temp = new XElement("object");
                    XAttribute type = new XAttribute("type", typeof(T));
                    XElement value = new XElement("value",innerArray[i]);
                    temp.Add(type);
                    temp.Add(value);
                    list.Add(temp);
                }
            }
            foreach (XElement temp in list)
            {
                Program.collection.Add(temp);
            }
            xDoc.Add(Program.collection);
            
        }

        public void readXML()
        {
           
        }
        public void Save()
        {
            xDoc.Save("Collection.xml");
        }
    }
}