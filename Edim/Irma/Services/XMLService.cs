using Irma.Context;
using Irma.Interface;
using Irma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Irma.Services
{
    public class XMLService : IXMLService
    {
        private readonly DatabaseContext _context;

        public XMLService(DatabaseContext context)
        {
            _context = context;
        }

        private DateTime pretvaranjeDatuma(String timestamp)
        {
            var datum = int.Parse(timestamp);
            var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(datum).ToLocalTime();
            return dt;
        }

        public void DodajXML(XmlDocument document)
        {
            XMLDoc doc = new XMLDoc();

            var timestamp = document.DocumentElement.FirstChild.LastChild.InnerText;
            var dt = pretvaranjeDatuma(timestamp);

            doc.VrijemeOcitanja = dt;
            _context.XMLDocs.Add(doc);
            _context.SaveChanges();
            
        }
        public Mjerenje DodajMjerenje(XmlNode senzor, int j)
        {
            Mjerenje mjerenje = new Mjerenje();

            var vrijemeMjerenja = pretvaranjeDatuma(senzor.ChildNodes[j].ChildNodes[14].InnerText);
            mjerenje.VrijemeMjerenja = vrijemeMjerenja;
            mjerenje.MinVrijednost = senzor.ChildNodes[j].ChildNodes[6].InnerText;
            mjerenje.MaxVrijednost = senzor.ChildNodes[j].ChildNodes[7].InnerText;
            mjerenje.Alarm = senzor.ChildNodes[j].ChildNodes[10].InnerText;
            mjerenje.VrijednostMjerenja = senzor.ChildNodes[j].ChildNodes[13].InnerText;
            mjerenje.ValidnostMjeranja = senzor.ChildNodes[j].ChildNodes[15].InnerText;

            _context.Mjerenja.Add(mjerenje);
            _context.SaveChanges();

            return mjerenje;
        }
        public bool ProvjeraSenzora(XmlNode senzor, int j)
        {
            var _senzor = _context.Senzori.FirstOrDefault(x => x.SenzorId == int.Parse(senzor.ChildNodes[j].Attributes[0].InnerText));
            if (_senzor == null)
                return false;
            else
                return true;
        }
        public void DodajSenzor(XmlNode senzor, int j)
        {
            Senzor _senzor = new Senzor();

            _senzor.ImeSenzora = senzor.ChildNodes[j].FirstChild.InnerText;
            _senzor.TipSenzora = senzor.ChildNodes[j].ChildNodes[2].InnerText;
            _senzor.SenzorId = int.Parse(senzor.ChildNodes[j].Attributes[0].InnerText);


            _context.Senzori.Add(_senzor);
            _context.SaveChanges();
        }

        public Senzor PronadjiSenzor(int id)
        {
           return _context.Senzori.FirstOrDefault(x => x.SenzorId == id);
        }

        public bool ProvjeraUredjaja(XmlNode uredjaj)
        {
            Uredjaj _uredjaj = _context.Uredjaji.FirstOrDefault(x => x.DeviceId == int.Parse(uredjaj.Attributes[0].InnerText));
            if (_uredjaj == null)
                return false;
            return true;
        }
        public void DodajUredjaj(XmlNode uredjaj)
        {
            Uredjaj _uredjaj = new Uredjaj();

            _uredjaj.Lokacija = uredjaj.ChildNodes[0].ChildNodes[0].InnerText;
            _uredjaj.DeviceId = int.Parse(uredjaj.Attributes[0].InnerText);
            
            _context.Uredjaji.Add(_uredjaj);
            _context.SaveChanges();
        }

    }
}
