using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Irma;
using Irma.Models;
using System.Xml.Linq;
using System.Net.Http;
using System.Xml;
using Irma.Services;
using Microsoft.Extensions.Configuration;
using Irma.Interface;
using Irma.Context;

namespace Irma.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class XMLDocsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IXMLService _service;
        //static readonly HttpClient client = new HttpClient();
        private readonly IConfiguration _config;

        public XMLDocsController(DatabaseContext context, IConfiguration configuration, IXMLService ixmlService)
        {
            _context = context;
            _config = configuration;
            _service = ixmlService;

        }

        // GET: api/XMLDocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<XMLDoc>>> GetXMLDocs()
        {
            var obj = await _context.XMLDocs.ToListAsync();
            return obj;
        }

        [HttpGet("getXML")]
        public void GetDocument()
        {
            //var startTimeSpan = TimeSpan.Zero;
            //var periodTimeSpan = TimeSpan.FromMinutes(1);

            //var timer = new System.Threading.Timer((e) =>
            //{
                string link = _config.GetSection("DataSource").Value;

                XmlDocument document = new XmlDocument();

                document.Load(link);

                _service.DodajXML(document);

                var devices = document.GetElementsByTagName("Device");
                var senzor = document.GetElementsByTagName("Sensors");

                //za svaki uredjaj ispitaj da li je null ako nije upisi u bazu
                List<Uredjaj> uredjaji = new List<Uredjaj>();

                foreach (XmlNode device in devices)
                {
                    if (!_service.ProvjeraUredjaja(device))
                    {
                        _service.DodajUredjaj(device);
                    }
                }

                //Za svaki uredjaj se ispituj njegovi parametri koji se upisuju u bazu

                foreach (Uredjaj uredjaj in uredjaji)
                {
                    switch (uredjaj.Lokacija)
                    {
                        case "SERVER SALA 1":
                            List<Mjerenje> mjerenja_sala1 = new List<Mjerenje>();

                            for (int j = 0; j < senzor[0].ChildNodes.Count; j++)
                            {
                                Mjerenje mjerenje = _service.DodajMjerenje(senzor[0], j);
                                mjerenja_sala1.Add(mjerenje);

                                if (!_service.ProvjeraSenzora(senzor[0], j))
                                {
                                    _service.DodajSenzor(senzor[0], j);
                                }
                                var _senzor = _service.PronadjiSenzor(int.Parse(senzor[0].ChildNodes[j].Attributes[0].InnerText));

                                _context.Senzori.FirstOrDefault(x => x.SenzorId == _senzor.SenzorId).Mjerenja = mjerenja_sala1;

                                _context.SaveChanges();

                            }
                            mjerenja_sala1 = new List<Mjerenje>();
                            break;
                        case "SERVER SALA 2":
                            List<Mjerenje> mjerenja_sala2 = new List<Mjerenje>();

                            for (int j = 0; j < senzor[1].ChildNodes.Count; j++)
                            {
                                Mjerenje mjerenje = _service.DodajMjerenje(senzor[1], j);
                                mjerenja_sala2.Add(mjerenje);

                                if (!_service.ProvjeraSenzora(senzor[1], j))
                                {
                                    _service.DodajSenzor(senzor[1], j);
                                }

                                var _senzor = _service.PronadjiSenzor(int.Parse(senzor[1].ChildNodes[j].Attributes[0].InnerText));

                                _context.Senzori.FirstOrDefault(x => x.SenzorId == _senzor.SenzorId).Mjerenja = mjerenja_sala2;

                                _context.SaveChanges();
                            }
                            mjerenja_sala2 = new List<Mjerenje>();
                            break;
                        case "KOTLOVNICA":
                            List<Mjerenje> mjerenja_kotlovnica = new List<Mjerenje>();
                            for (int j = 0; j < senzor[2].ChildNodes.Count; j++)
                            {
                                Mjerenje mjerenje = _service.DodajMjerenje(senzor[1], j);
                                mjerenja_kotlovnica.Add(mjerenje);

                                if (!_service.ProvjeraSenzora(senzor[2], j))
                                {
                                    _service.DodajSenzor(senzor[2], j);
                                }

                                var _senzor = _service.PronadjiSenzor(int.Parse(senzor[2].ChildNodes[j].Attributes[0].InnerText));

                                _context.Senzori.FirstOrDefault(x => x.SenzorId == _senzor.SenzorId).Mjerenja = mjerenja_kotlovnica;

                                _context.SaveChanges();
                            }
                            mjerenja_kotlovnica = new List<Mjerenje>();
                            break;
                        default:
                            continue;
                    }
                }
            //}, null, startTimeSpan, periodTimeSpan);
        }

        


        private bool XMLDocExists(long id)
        {
            return _context.XMLDocs.Any(e => e.Id == id);
        }
    }
}
