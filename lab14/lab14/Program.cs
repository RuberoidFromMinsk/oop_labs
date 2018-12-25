using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization;

namespace lab14
{
    [DataContract]
    [Serializable]
    public abstract class Aviation
    {
        [DataMember]
        protected string _name;

        public Aviation() { }

        public Aviation(string _name)
        {
            this._name = _name;
        }


        public virtual void GetName()
        {
            Console.WriteLine("Name:" + _name);
        }
        public abstract int GetCapacity();
        public abstract int GetCarrying();
        public abstract int GetDistance();
        public abstract void Display();
    }

    [DataContract]
    [Serializable]
    public class PassangerPlane : Aviation
    {
        [DataMember]
        public int passangerCapacity;

        public PassangerPlane() { }

        public PassangerPlane(int passangerCapacity, string _name) : base(_name)
        {
            this.passangerCapacity = passangerCapacity;
        }

        public override void GetName()
        {
            Console.WriteLine($"Passanger plane: {_name}");
        }

        public override int GetCapacity()
        {
            return passangerCapacity;
        }
        public override int GetCarrying()
        {
            throw new NotImplementedException();
        }
        public override int GetDistance()
        {
            throw new NotImplementedException();
        }
        public override void Display()
        {
            Console.WriteLine($"Passanger capacity: {passangerCapacity}   Name:{_name} Type: {this.GetType()}");
        }
    }
    class XML
    {
        public static void XPath()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("NewXMLdoc.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("/buttons/button");
            foreach (XmlNode n in childnodes)
            { Console.WriteLine(n.InnerText); }
        }
        public static void CreateDoc()
        {
            XDocument XMLdoc = new XDocument();

            XElement accept = new XElement("button");
            XAttribute accept_title = new XAttribute("title", "first button");
            XElement accept_count = new XElement("count", "1");
            accept.Add(accept_title);
            accept.Add(accept_count);

            XElement exit = new XElement("button");
            XAttribute exit_title = new XAttribute("title", "second button");
            XElement exit_count = new XElement("count", "3");
            exit.Add(exit_title);
            exit.Add(exit_count);

            XElement reload = new XElement("button");
            XAttribute reload_title = new XAttribute("title", "third button");
            XElement reload_count = new XElement("count", "5");
            reload.Add(reload_title);
            reload.Add(reload_count);

            XElement repeat = new XElement("button");
            XAttribute repeat_title = new XAttribute("title", "fourth button");
            XElement repeat_count = new XElement("count", "3");
            repeat.Add(repeat_title);
            repeat.Add(repeat_count);

            XElement buttons = new XElement("buttons");
            buttons.Add(accept);
            buttons.Add(exit);
            buttons.Add(reload);
            buttons.Add(repeat);

            XMLdoc.Add(buttons);

            XMLdoc.Save("NewXMLdoc.xml");

            var request_1 = from item in XMLdoc.Descendants("button") where item.Element("count").Value == "3" select item;

            Console.WriteLine("\nLINQ to XML 1:");
            foreach (var item in request_1)
                Console.WriteLine(item.LastAttribute);

            /*var request_2 = from item in XMLdoc.Descendants("button") where item.Element("count").Value == "5" select item;

            Console.WriteLine("\nLINQ to XML 2:");

            if(request_2.Count() != 0)
            {
                foreach (var a in request_2)
                    a.Remove();

                Console.WriteLine("Элемент удален");
            }
            else
            {
                Console.WriteLine("Элемент не найден");
            }*/
        }
        public static void Print()
        {
            XDocument xdoc = XDocument.Load("NewXMLdoc.xml");
            foreach (XElement button in xdoc.Element("buttons").Elements("button"))
            {
                XAttribute title = button.Attribute("title");
                XElement count = button.Element("count");
                if (title != null && count != null)
                {
                    Console.WriteLine("Button's title: {0}", title.Value);
                    Console.WriteLine("Count of: {0}", count.Value);
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PassangerPlane plane = new PassangerPlane(100, "Airbus");
            Console.WriteLine("Object has been created");

            BinaryFormatter BINformatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("plane.dat", FileMode.OpenOrCreate))
            {
                BINformatter.Serialize(fs, plane);
          
                Console.WriteLine("\nBinary serialize - success");
            }

            Console.WriteLine();

            using (FileStream fs = new FileStream("plane.dat", FileMode.OpenOrCreate))
            {
                PassangerPlane newPlane = (PassangerPlane)BINformatter.Deserialize(fs);

                newPlane.Display();

                Console.WriteLine("\nBinary deserialize - success");
            }

            SoapFormatter SOAPformatter = new SoapFormatter();
            using (FileStream fs = new FileStream("plane.soap", FileMode.OpenOrCreate))
            {
                SOAPformatter.Serialize(fs, plane);

                Console.WriteLine("\nSOAP serialize - success\n");
            }
            using (FileStream fs = new FileStream("plane.soap", FileMode.OpenOrCreate))
            {
                PassangerPlane soapplane = (PassangerPlane)SOAPformatter.Deserialize(fs);

                soapplane.Display();

                Console.WriteLine("\nSOAP deserialize - success");
            }

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(PassangerPlane));

            using (FileStream fs = new FileStream("plane.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, plane);

                Console.WriteLine("\nJSON serialize - success\n");
            }

            using (FileStream fs = new FileStream("plane.json", FileMode.OpenOrCreate))
            {
                PassangerPlane jsonplane = (PassangerPlane)jsonFormatter.ReadObject(fs);

                jsonplane.Display();

                Console.WriteLine("\nJSON deserialize - success");
            }

            XmlSerializer XMLformatter = new XmlSerializer(typeof(PassangerPlane));

            
            using (FileStream fs = new FileStream("plane.xml", FileMode.OpenOrCreate))
            {
                XMLformatter.Serialize(fs, plane);

                Console.WriteLine("\nXML deserialize - success\n");
            }

            
            using (FileStream fs = new FileStream("plane.xml", FileMode.OpenOrCreate))
            {
                PassangerPlane xmlplane = (PassangerPlane)XMLformatter.Deserialize(fs);

                xmlplane.Display();

                Console.WriteLine("\nXML deserialize - success\n");
            }

            //Task2
            PassangerPlane plane2 = new PassangerPlane(1450, "Plane2");
            PassangerPlane[] planes = { plane, plane2 };

            SoapFormatter collectionFormatter = new SoapFormatter();
            
            using (FileStream fs = new FileStream("collection.soap", FileMode.OpenOrCreate))
            {
                collectionFormatter.Serialize(fs, planes);

                Console.WriteLine("Массив сериализован");
            }

            
            using (FileStream fs = new FileStream("collection.soap", FileMode.OpenOrCreate))
            {
                PassangerPlane[] newcollection = (PassangerPlane[])collectionFormatter.Deserialize(fs);

                foreach (PassangerPlane p in newcollection)
                {
                    p.Display();
                }
                Console.WriteLine("Массив десериализован\n");
            }

            XML.CreateDoc();
            XML.XPath();
            XML.Print();

            

            Console.ReadKey();
        }
    }
}
