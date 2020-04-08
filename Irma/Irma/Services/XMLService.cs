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
            //prikom svakog ocitanja xml-a u liste se spašavaju vrijednosti
            List<string> imenaSenzora = new List<string>();
            List<string> tipoviSenzora = new List<string>();
            List<string> vremenaMjerenja = new List<string>();
            List<string> minVrijednosti = new List<string>();
            List<string> maxVrijednosti = new List<string>();
            List<string> alarmi = new List<string>();
            List<string> vrijednostiMjerenja = new List<string>();
            List<string> validnostiMjerenja = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                if (listaLokacija[i] == "Server sala 1")
                {
                    var senzor = document.GetElementsByTagName("Sensors");
                    for (int j = 0; j < 6; j++)
                    {
                        imenaSenzora.Add(senzor[0].ChildNodes[j].FirstChild.InnerText);

                        //tip mjerenja
                        string tip = senzor[0].ChildNodes[j].ChildNodes[2].InnerText;
                        tipoviSenzora.Add(tip);

                        // vrijeme mjerenja
                        string vrijemeMjerenja = senzor[0].ChildNodes[j].ChildNodes[14].InnerText;
                        vremenaMjerenja.Add(vrijemeMjerenja);

                        //min vrijednost
                        string minVrijednost = senzor[0].ChildNodes[j].ChildNodes[6].InnerText;
                        minVrijednosti.Add(minVrijednost);

                        //max vrijednost
                        string maxVrijednost = senzor[0].ChildNodes[j].ChildNodes[7].InnerText;
                        maxVrijednosti.Add(maxVrijednost);

                        //alarm
                        string alarm = senzor[0].ChildNodes[j].ChildNodes[10].InnerText;
                        alarmi.Add(alarm);

                        //vrijednost mjerenja
                        string vrijednostMjerenja = senzor[0].ChildNodes[j].ChildNodes[13].InnerText;
                        vrijednostiMjerenja.Add(vrijednostMjerenja);

                        //validnost mjerenja
                        string validnost = senzor[0].ChildNodes[j].ChildNodes[15].InnerText;
                        validnostiMjerenja.Add(validnost);
                    }


                }
                if (listaLokacija[i] == "Kotlovnica")
                {
                    var senzor = document.GetElementsByTagName("Sensors");
                    for (int j = 0; j < 6; j++)
                    {
                        imenaSenzora.Add(senzor[1].ChildNodes[j].FirstChild.InnerText);

                        //tip mjerenja
                        string tip = senzor[1].ChildNodes[j].ChildNodes[2].InnerText;
                        tipoviSenzora.Add(tip);

                        // vrijeme mjerenja
                        string vrijemeMjerenja = senzor[1].ChildNodes[j].ChildNodes[14].InnerText;
                        vremenaMjerenja.Add(vrijemeMjerenja);

                        //min vrijednost
                        string minVrijednost = senzor[1].ChildNodes[j].ChildNodes[6].InnerText;
                        minVrijednosti.Add(minVrijednost);

                        //max vrijednost
                        string maxVrijednost = senzor[1].ChildNodes[j].ChildNodes[7].InnerText;
                        maxVrijednosti.Add(maxVrijednost);

                        //alarm
                        string alarm = senzor[1].ChildNodes[j].ChildNodes[10].InnerText;
                        alarmi.Add(alarm);

                        //vrijednost mjerenja
                        string vrijednostMjerenja = senzor[1].ChildNodes[j].ChildNodes[13].InnerText;
                        vrijednostiMjerenja.Add(vrijednostMjerenja);

                        //validnost mjerenja
                        string validnost = senzor[1].ChildNodes[j].ChildNodes[15].InnerText;
                        validnostiMjerenja.Add(validnost);
                    }
                }
                if (listaLokacija[i] == "Server sala 2")
                {
                    var senzor = document.GetElementsByTagName("Sensors");
                    for (int j = 0; j < 6; j++)
                    {
                        imenaSenzora.Add(senzor[2].ChildNodes[j].FirstChild.InnerText);

                        //tip mjerenja
                        string tip = senzor[2].ChildNodes[j].ChildNodes[2].InnerText;
                        tipoviSenzora.Add(tip);

                        // vrijeme mjerenja
                        string vrijemeMjerenja = senzor[2].ChildNodes[j].ChildNodes[14].InnerText;
                        vremenaMjerenja.Add(vrijemeMjerenja);

                        //min vrijednost
                        string minVrijednost = senzor[2].ChildNodes[j].ChildNodes[6].InnerText;
                        minVrijednosti.Add(minVrijednost);

                        //max vrijednost
                        string maxVrijednost = senzor[2].ChildNodes[j].ChildNodes[7].InnerText;
                        maxVrijednosti.Add(maxVrijednost);

                        //alarm
                        string alarm = senzor[2].ChildNodes[j].ChildNodes[10].InnerText;
                        alarmi.Add(alarm);

                        //vrijednost mjerenja
                        string vrijednostMjerenja = senzor[2].ChildNodes[j].ChildNodes[13].InnerText;
                        vrijednostiMjerenja.Add(vrijednostMjerenja);

                        //validnost mjerenja
                        string validnost = senzor[2].ChildNodes[j].ChildNodes[15].InnerText;
                        validnostiMjerenja.Add(validnost);
                    }
                }
            }

        }
    }
}
