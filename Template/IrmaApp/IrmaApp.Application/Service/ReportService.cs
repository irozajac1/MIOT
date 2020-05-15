using IrmaApp.Core.Entity;
using IrmaApp.Core.Interface;
using IrmaApp.Core.Model.Request;
using IrmaApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IrmaApp.Core.Model.Response
{
    public class ReportService : IReportService
    {
        private readonly DatabaseContext database;
        //private readonly Senzor senzor;
        //private readonly Uredjaj uredjaj;
        //private readonly IConfiguration _config;

        public ReportService(DatabaseContext database)
        {
            this.database = database;
            //this.senzor = senzor;
            //this.uredjaj = uredjaj;
            //_config = configuration;
        }

       
        public List<Senzor> GetReportBySenzorName(RequestReport report)
        {
            List<Senzor> dataBaseResponse = database.Senzori.
                Where(x => x.ImeSenzora == report.ImeSenzora && report.MjestoSenzora == x.Uredjaj.Lokacija && report.VrijemeOd == x.VrijemeMjerenja).Include(x => x.Uredjaj).
                ToList();
            return dataBaseResponse;
        }

        public List<SenzorDTO> GetReportBySenzorNameDTO(List<Senzor> senzori)
        {
            List<SenzorDTO> senzorDTOs = new List<SenzorDTO>();

            foreach (Senzor senzor in senzori)
            {
                SenzorDTO senzorDTO = new SenzorDTO()
                {
                    MaxVrijednost = senzor.MaxVrijednost,
                    MinVrijednost = senzor.MinVrijednost,
                    Id = senzor.Id,
                    VrijednostMjerenja = senzor.VrijednostMjerenja,
                    VrijemeMjerenja = senzor.VrijemeMjerenja,
                    Alarm = senzor.Alarm,
                    ImeSenzora = senzor.ImeSenzora,
                    SenzorId = senzor.SenzorId,
                    TipSenzora = senzor.TipSenzora,
                    Uredjaj = senzor.Uredjaj.Id,
                    ValidnostMjeranja = senzor.ValidnostMjeranja
                    
                };
                senzorDTOs.Add(senzorDTO);
            }
            return senzorDTOs; 
        }

        public List<ResponseReport> GenerateMeasurementRepot(List<SenzorDTO> senzorDTOs)
        {
            List<ResponseReport> responseReports = new List<ResponseReport>();
            foreach (SenzorDTO senzorDTO in senzorDTOs)
            {
                var response = new ResponseReport
                {
                    Mjerenje = senzorDTO,
                    Poruka = "Ok"
                };
                responseReports.Add(response);
            }
            return responseReports;
        }
    }
}
