using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Irma.Services
{
    public class XMLService
    {
        public void GetXML()
        {
            string link = "http://sensdesk.com/sensdesk/values.xml?values_xml_key=09QR8Atm0dfcf1xk-ob7j-IvG3v0mq9YB6Pv4WtoJUs";
            XmlDocument document = new XmlDocument();
            document.Load(link);
            //Console.WriteLine(document.InnerXml);

            var xmlString = XElement.Parse(document.InnerXml);

            //vrijeme mjerenja za sve
            var timeStamp = document.DocumentElement.FirstChild.LastChild.InnerText;

            //id uredjaja-- ne znam jel bi trebalo preko for petlje ili ovako posebno a vjerovatno posebno 
            //i uz ovo ide ime lokacije u zavisnosti od id uredjaja
            var device = document.GetElementsByTagName("Device");
            string imeLokacije = "";
            List<string> listaLokacija = new List<string>();
            List<string> listaIDUredjaja = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                var rezultat = device[i].Attributes[0].InnerText;
                listaIDUredjaja.Add(rezultat);
                Console.WriteLine(rezultat);

                if (i == 0) imeLokacije = "Server sala 1";
                if (i == 1) imeLokacije = "Kotlovnica";
                if (i == 2) imeLokacije = "Server sala 2";

                listaLokacija.Add(imeLokacije);

            }
            var devIDServersala1 = device[0].Attributes[0].InnerText;
            var devIDKotlovnica = device[1].Attributes[0].InnerText;
            var devIDServersala2 = device[2].Attributes[0].InnerText;

            Console.WriteLine(listaLokacija);


            //naziv senzora i tip (na osnovu naziva možes napisati tip bez da ga izvlacis iz xml-a
            List<string> imenaSenzora = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                if (listaLokacija[i] == "Server sala 1")
                {
                    var senzor = document.GetElementsByTagName("Sensors");
                    for (int j = 0; j < 6; j++)
                    {
                        imenaSenzora.Add(senzor[0].ChildNodes[j].FirstChild.InnerText);
                    }

                }
                if (listaLokacija[i] == "Kotlovnica")
                {
                    var senzor = document.GetElementsByTagName("Sensors");
                    var imeSenzora = senzor[1].FirstChild.FirstChild.InnerText;
                }
                if (listaLokacija[i] == "Server sala 2")
                {
                    var senzor = document.GetElementsByTagName("Sensors");
                    var imeSenzora = senzor[2].FirstChild.FirstChild.InnerText;
                }
            }

        }
    }
}
