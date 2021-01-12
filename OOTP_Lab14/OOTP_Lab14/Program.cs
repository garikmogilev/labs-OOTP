using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Runtime.Serialization;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Xml;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Train train1 = new Train("gray", "yellow", 5000, "diesel");
            Train train2 = new Train("blue", "green", 5000, "diesel");
            Train train3 = new Train("grey", "red", 5000, "diesel");
            Train train4 = new Train("pink", "black", 5000, "diesel");
            Train train5 = new Train("black", "violet", 5000, "diesel");

            Engine engine = new Engine(5000, "petroil");
            Array trains = new[] {train1, train2, train3, train4, train5};
            
            //******** Task first ********// 
            // Binary mode
            string FileName = "data.dat";
            BinaryFormatter bin = new BinaryFormatter();

            using (FileStream file = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                bin.Serialize(file, trains);
            }

            Console.WriteLine($"Write bin in file:{FileName}");

            using (FileStream file = new FileStream(FileName, FileMode.Open))
            {
                Train[] deserializeTrains = (Train[]) bin.Deserialize(file);
                Console.WriteLine("Bin deserialized.");
                foreach (var train in deserializeTrains)
                {
                    Console.WriteLine(
                        $"Train color: {train?.Color}, Color interior: {train?.Interier}, Type fuel engine: {train?.Engine?.Fuel}");
                }
                Console.WriteLine();
            }

            // Soap mode
            string FileNameSoap = "data.soap";
            SoapFormatter soap = new SoapFormatter();

            using (FileStream file = new FileStream(FileNameSoap, FileMode.OpenOrCreate))
            {
                soap.Serialize(file, trains);
            }

            Console.WriteLine($"Write soap in file: {FileNameSoap}");

            using (FileStream file = new FileStream(FileNameSoap, FileMode.Open))
            {
                Train[] deserializeTrains = (Train[]) soap.Deserialize(file);
                Console.WriteLine("Soap deserialized.");
                foreach (var train in deserializeTrains)
                {
                    Console.WriteLine(
                        $"Train color: {train?.Color}, Color interior: {train?.Interier}, Type fuel engine: {train?.Engine?.Fuel}");
                }
                Console.WriteLine();
            }
            // JSON mode
            string FileNameJSON = "data.json";
            DataContractJsonSerializer json= new DataContractJsonSerializer(typeof(Train[]));
            using (FileStream file = new FileStream(FileNameJSON, FileMode.OpenOrCreate))
            {
                json.WriteObject(file, trains);
                Console.WriteLine($"Write json in file: {FileNameJSON}");
            }
            using (FileStream file = new FileStream(FileNameJSON, FileMode.OpenOrCreate))
            {
                Train[] deserializeTrains = (Train[])json.ReadObject(file);
                Console.WriteLine("Json deserialized.");
                foreach (var train in deserializeTrains)
                {
                    Console.WriteLine(
                        $"Train color: {train?.Color}, Color interior: {train?.Interier}, Type fuel engine: {train?.Engine?.Fuel}");
                }
                Console.WriteLine();
            }

            // XML mode
            string FileNameXML = "data.xml";
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Train[]));
            using (Stream file = new FileStream(FileNameXML, FileMode.OpenOrCreate))
            {
                xmlFormat.Serialize(file, trains);
            }
            Console.WriteLine("Write data XML-format");
            
            using (FileStream file = new FileStream(FileNameXML, FileMode.Open))
            {
                Train[] deserializeTrains = (Train[])xmlFormat.Deserialize(file);
                Console.WriteLine("XML deserialized");
                foreach (var train in deserializeTrains)
                {
                    Console.WriteLine(
                        $"Train color: {train?.Color}, Color interior: {train?.Interier}, Type fuel engine: {train?.Engine?.Fuel}");
                }
                Console.WriteLine();
            }
            
            //******** Task second ********// 
            List<int> numbers = new List<int> {10, 65, 23, 445, 34};
            
            string fileNameXmlNumbers = "numbers.xml";
            XmlSerializer xmlFormater = new XmlSerializer(typeof(List<int>));
            using (Stream file = new FileStream(fileNameXmlNumbers, FileMode.OpenOrCreate))
            {
                xmlFormater.Serialize(file, numbers);
            }
            Console.WriteLine("Write data XML-format");
            
            using (FileStream file = new FileStream(fileNameXmlNumbers, FileMode.Open))
            {
                List<int> deserializeNumbers = (List<int>)xmlFormater.Deserialize(file);
                Console.WriteLine("XML deserialized");
                foreach (var number in numbers)
                {
                    Console.WriteLine($"{number.ToString()}");
                }
                Console.WriteLine();
            }
            
            //******** Task third ********// 
            XmlDocument XDoc = new XmlDocument();
            XDoc.Load(FileNameXML);
            XmlElement xRoot = XDoc.DocumentElement;
            
            XmlNodeList childnodes1 = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes1)
                Console.WriteLine(n.OuterXml);
            Console.WriteLine();
            
            XmlNodeList childnodes2 = xRoot.SelectNodes("Train/_color");
            foreach (XmlNode n in childnodes2)
                Console.WriteLine(n.OuterXml);
            Console.WriteLine();

            XmlNodeList childnodes3 = xRoot.SelectNodes("Train[_color = 'black']");
            foreach (XmlNode n in childnodes3)
                Console.WriteLine(n.OuterXml);
            Console.WriteLine();
            
            //******** Task fourth ********//
            XDocument linqXML = new XDocument(
                new XElement("CollectionTrains",
                new XElement("Train",
                    new XElement("_color","yellow"),
                    new XElement("_interier","gray")
                        ),
                new XElement("Train",
                    new XElement("_color","red"),
                    new XElement("_interier","gray")
                ),
                new XElement("Train",
                    new XElement("_color","red"),
                    new XElement("_interier","gray")))
                );
            linqXML.Save("linqXML.xml");
            
            XDocument xdoc = XDocument.Load(@"linqXML.xml");
            var items = from x in xdoc.Element("CollectionTrains").Elements("Train")
                where x.Element("_color").Value == "red"
                select x;

            foreach (XElement item in items)
                Console.WriteLine(item?.ToString());

        }
    }
}