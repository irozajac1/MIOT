using Irma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Irma.Interface
{
    public interface IXMLService
    {
        Mjerenje DodajMjerenje(XmlNode senzor, int j);
        void DodajXML(XmlDocument document);
        void DodajSenzor(XmlNode senzor, int j);
        bool ProvjeraSenzora(XmlNode senzor, int j);
        Senzor PronadjiSenzor(int id);
        void DodajUredjaj(XmlNode uredjaj);
        bool ProvjeraUredjaja(XmlNode uredjaj);
        //Uredjaj PronadjiUredjaj(int id);
    }
}
