using System;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

using System.Xml.Serialization;
using System.Xml;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Technic tech = new Technic("Comp", "Компьютер");
            Technic tech1 = new Technic("Pad", "Планшет");
            Technic tech2 = new Technic("Print", "Принтер");
            Technic[] technica = new Technic[] { tech, tech1, tech2 };

            Console.WriteLine($"{tech.TypePro }--{tech.nameProduct}");

            //бинарный
            BinaryFormatter BinaryForm = new BinaryFormatter();
            using (FileStream file = new FileStream("BinSer.dat", FileMode.OpenOrCreate)) //открывает или создает
            {
                Console.WriteLine("Бинарная сериализация");
                BinaryForm.Serialize(file, tech); //поток сериализации и объект
            }
            using (FileStream file = new FileStream("BinSer.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine("Бинарная десериализация");
                Technic NewTech = (Technic)BinaryForm.Deserialize(file);
                Console.WriteLine($"{NewTech.TypePro} - {NewTech.nameProduct}");
            }

            ///SOAP
            ///


            SoapFormatter format = new SoapFormatter();
            using (FileStream file = new FileStream("SoapSer.soap", FileMode.OpenOrCreate))
            {
                format.Serialize(file, tech);

                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream file = new FileStream("SoapSer.soap", FileMode.OpenOrCreate))
            {
                Technic NewTech = (Technic)format.Deserialize(file);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"{NewTech.TypePro} - {NewTech.nameProduct}");
            }
            /*JSON*/

            DataContractJsonSerializer JsonForm = new DataContractJsonSerializer(typeof(Technic));
            using (FileStream fs = new FileStream("TECH.json", FileMode.OpenOrCreate))
            {
                JsonForm.WriteObject(fs, tech1);
                Console.WriteLine("Book serialized.");
            }
            using (FileStream fs = new FileStream("TECH.json", FileMode.OpenOrCreate))
            {
                Technic newBook = (Technic)JsonForm.ReadObject(fs);
                Console.WriteLine("Book deserialized.");
                Console.WriteLine(tech1.ToString());
            }


            /*XML формат*/
            XmlSerializer XmlSerializer = new XmlSerializer(typeof(Technic));
            using (FileStream fs = new FileStream("XmlSer.xml", FileMode.Create))
            {
                XmlSerializer.Serialize(fs, tech);
                Console.WriteLine("XML сериализация");
            }
            using (FileStream fs = new FileStream("XmlSer.xml", FileMode.Open))
            {
                Technic yan1 = (Technic)XmlSerializer.Deserialize(fs);
                Console.WriteLine("XML десериализация");
            }

            /*Создайте коллекцию (массив) объектов и выполните сериализацию/десериализацию.*/

            XmlSerializer XmlSerializer1 = new XmlSerializer(typeof(Technic[]));
            using (FileStream file = new FileStream("BSerArr.dat", FileMode.OpenOrCreate))
            {
                XmlSerializer1.Serialize(file, technica);
                Console.WriteLine("Массив Сериализзован");
            }
            using (FileStream fs = new FileStream("BSerArr.dat", FileMode.Open))
            {

                Technic[] newpeople = (Technic[])XmlSerializer1.Deserialize(fs);
                Console.WriteLine("Массив Десериализзован");
            }

            /*Используя XPath напишите два селектора для вашего XML документа.*/


            XDocument xDocument = new XDocument();
            XElement Technic1 = new XElement("Technica");
            XElement name1 = new XElement("name", "Телефон");
            XElement age1 = new XElement("age", "3");
            Technic1.Add(name1);
            Technic1.Add(age1);
            XElement Technic2 = new XElement("Technica");
            XElement name2 = new XElement("name", "Ноутбук");
            XElement age2 = new XElement("age", "2");
            Technic2.Add(name2);
            Technic2.Add(age2);
            XElement People = new XElement("Tech");
            People.Add(Technic1);
            People.Add(Technic2);
            xDocument.Add(People);
            xDocument.Save("D:/2КУРС/ООП/LABA14/ConsoleApp1/bin/Debug/XmlSerArr.xml");

            /*  Используя Linq to XML(или Linq to JSON) создайте новый xml(json) -
  документ и напишите несколько запросов.*/

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("D:/2КУРС/ООП/LABA14/ConsoleApp1/bin/Debug/XmlSerArr.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlNodeList childnodes = xRoot.SelectNodes("//Technica/name");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.InnerText);

            childnodes = xRoot.SelectNodes("//Technica/age");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.InnerText);
        }
    }

    internal class XDocument
    {
    }

    [Serializable]
    abstract class Product///абстракный класс
    {
        public string nameProduct;
    }

    [Serializable]
    public class Technic
    {
        public int id;
        public string TypePro { get; set; }
        public string nameProduct { get; set; }
        public Technic(string TypePro, string nameProduct)
        {
            this.nameProduct = nameProduct;
        }

        public virtual void Write()
        {
            Console.WriteLine("Тип продукта " + TypePro);
        }
        public Technic()
        {

        }

    }
}