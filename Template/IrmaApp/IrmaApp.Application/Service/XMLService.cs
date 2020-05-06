using IrmaApp.Core.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using IrmaApp.Core.Entity;
using IrmaApp.Infrastructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace IrmaApp.Core.Service
{
    public class XMLService : IXMLService
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _config;

        public XMLService(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
        }
        public String getXmlDocument()
        {
            string link = _config.GetSection("DataSource").Value;

            XmlDocument document = new XmlDocument();

            document.Load(link);

            var timestamp = document.DocumentElement.FirstChild.LastChild.InnerText;
            var dt = pretvaranjeDatuma(timestamp);

            XMLDoc doc = new XMLDoc();
            doc.VrijemeOcitanja = dt;
            _context.XMLDocs.Add(doc);


            var devices = document.GetElementsByTagName("Device");
            var senzor = document.GetElementsByTagName("Sensors");

            //za svaki uredjaj ispitaj da li je null ako nije upisi u bazu
            List<Uredjaj> uredjaji = new List<Uredjaj>();

            foreach (XmlNode device in devices)
            {
               if (!ProvjeraUredjaja(device))
                {
                    Uredjaj _uredjaj = new Uredjaj();

                    _uredjaj.Lokacija = device.ChildNodes[0].ChildNodes[0].InnerText;
                    _uredjaj.DeviceId = int.Parse(device.Attributes[0].InnerText);

                    uredjaji.Add(_uredjaj);
                    _context.Uredjaji.Add(_uredjaj);

                }
                    
            }
            //foreach (Uredjaj uredjaj in uredjaji)device.ChildNodes[0].ChildNodes[0].InnerText
            foreach (Uredjaj uredjaj in _context.Uredjaji)
            {
                switch (uredjaj.Lokacija)
                {
                    case "SERVER SALA 1":
                        List<Senzor> mjerenja_sala1 = new List<Senzor>();


                        for (int j = 0; j < senzor[0].ChildNodes.Count; j++)
                        {
                            Senzor _senzor = new Senzor();
                            if (ProvjeraSenzora(senzor[0], j))
                            {
                                _senzor.ImeSenzora = senzor[0].ChildNodes[j].FirstChild.InnerText;
                                _senzor.SenzorId = int.Parse(senzor[0].ChildNodes[j].Attributes[0].InnerText);
                                _senzor.TipSenzora = senzor[0].ChildNodes[j].ChildNodes[2].InnerText;
                                _senzor.MinVrijednost = senzor[0].ChildNodes[j].ChildNodes[6].InnerText;
                                _senzor.MaxVrijednost = senzor[0].ChildNodes[j].ChildNodes[7].InnerText;
                                _senzor.Alarm = senzor[0].ChildNodes[j].ChildNodes[10].InnerText;
                                _senzor.VrijednostMjerenja = senzor[0].ChildNodes[j].ChildNodes[13].InnerText;
                                _senzor.ValidnostMjeranja = senzor[0].ChildNodes[j].ChildNodes[15].InnerText;
                                _senzor.VrijemeMjerenja = pretvaranjeDatuma(senzor[0].ChildNodes[j].ChildNodes[14].InnerText);
                                _senzor.UredjajId = uredjaj.DeviceId;

                                _context.Senzori.Add(_senzor);
                            }
                            mjerenja_sala1.Add(_senzor);

                            uredjaj.Senzori = mjerenja_sala1;
                            //var uredjajProvjere = NadjiUredjaj(int.Parse(uredjajProvjere.ChildNodes[0].ChildNodes[0].InnerText));

                            //_context.Uredjaji.FirstOrDefault(x => x.DeviceId == uredjajProvjere.DeviceId).Senzori = mjerenja_sala1;

                        }
                       
                        break;
                    case "KOTLOVNICA":
                        List<Senzor> kotlovnica = new List<Senzor>();

                        for (int j = 0; j < senzor[1].ChildNodes.Count; j++)
                        {
                            Senzor _senzor = new Senzor();
                            if (ProvjeraSenzora(senzor[1], j))
                            {
                                _senzor.ImeSenzora = senzor[1].ChildNodes[j].FirstChild.InnerText;
                                _senzor.SenzorId = int.Parse(senzor[1].ChildNodes[j].Attributes[0].InnerText);
                                _senzor.TipSenzora = senzor[1].ChildNodes[j].ChildNodes[2].InnerText;
                                _senzor.MinVrijednost = senzor[1].ChildNodes[j].ChildNodes[6].InnerText;
                                _senzor.MaxVrijednost = senzor[1].ChildNodes[j].ChildNodes[7].InnerText;
                                _senzor.Alarm = senzor[1].ChildNodes[j].ChildNodes[10].InnerText;
                                _senzor.VrijednostMjerenja = senzor[1].ChildNodes[j].ChildNodes[13].InnerText;
                                _senzor.ValidnostMjeranja = senzor[1].ChildNodes[j].ChildNodes[15].InnerText;
                                _senzor.VrijemeMjerenja = pretvaranjeDatuma(senzor[1].ChildNodes[j].ChildNodes[14].InnerText);
                                _senzor.UredjajId = uredjaj.DeviceId;

                                _context.Senzori.Add(_senzor);
                            }
                            kotlovnica.Add(_senzor);
                            uredjaj.Senzori = kotlovnica;
                        }
                        break;
                    case "SERVER SALA 2":
                        List<Senzor> mjerenja_sala2 = new List<Senzor>();

                        for (int j = 0; j < senzor[2].ChildNodes.Count; j++)
                        {
                            Senzor _senzor = new Senzor();
                            if (ProvjeraSenzora(senzor[0], j))
                            {
                                _senzor.ImeSenzora = senzor[2].ChildNodes[j].FirstChild.InnerText;
                                _senzor.SenzorId = int.Parse(senzor[2].ChildNodes[j].Attributes[0].InnerText);
                                _senzor.TipSenzora = senzor[2].ChildNodes[j].ChildNodes[2].InnerText;
                                _senzor.MinVrijednost = senzor[2].ChildNodes[j].ChildNodes[6].InnerText;
                                _senzor.MaxVrijednost = senzor[2].ChildNodes[j].ChildNodes[7].InnerText;
                                _senzor.Alarm = senzor[2].ChildNodes[j].ChildNodes[10].InnerText;
                                _senzor.VrijednostMjerenja = senzor[2].ChildNodes[j].ChildNodes[13].InnerText;
                                _senzor.ValidnostMjeranja = senzor[2].ChildNodes[j].ChildNodes[15].InnerText;
                                _senzor.VrijemeMjerenja = pretvaranjeDatuma(senzor[2].ChildNodes[j].ChildNodes[14].InnerText);
                                _senzor.UredjajId = uredjaj.DeviceId;

                                _context.Senzori.Add(_senzor);
                            }
                            mjerenja_sala2.Add(_senzor);
                            uredjaj.Senzori = mjerenja_sala2;
                        }
                        break;
                }
                       
                        continue;
                
            }
            _context.SaveChanges();
            return "radi";
        }

        private DateTime pretvaranjeDatuma(String timestamp)
        {
            var datum = int.Parse(timestamp);
            var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(datum).ToLocalTime();
            return dt;
        }
        private bool ProvjeraSenzora(XmlNode senzor, int j)
        {
            var _senzor = _context.Senzori.FirstOrDefault(x => x.SenzorId == int.Parse(senzor.ChildNodes[j].Attributes[0].InnerText));
            if (_senzor == null)
                return false;
            else
            return true;

        }

        private bool ProvjeraUredjaja(XmlNode uredjaj)
        {
            var _uredjaj = _context.Uredjaji.FirstOrDefault(x => x.DeviceId == int.Parse(uredjaj.Attributes[0].InnerText));
            if (_uredjaj != null) return true;
            else
            return false;
        }

        private Uredjaj NadjiUredjaj(int id)
        {
            return _context.Uredjaji.FirstOrDefault(x => x.DeviceId == id);
        }
    }
}
