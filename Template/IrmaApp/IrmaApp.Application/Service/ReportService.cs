using IrmaApp.Core.Entity;
using IrmaApp.Core.Model.Request;
using IrmaApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IrmaApp.Core.Model.Response
{
    public class ReportService
    {
        //private readonly Senzor senzor;
        //private readonly Uredjaj uredjaj;
        //private readonly DatabaseContext database;

        //public ReportService(Senzor senzor, Uredjaj uredjaj, DatabaseContext database)
        //{
        //    this.senzor = senzor;
        //    this.uredjaj = uredjaj;
        //    this.database = database;
        //}

        //public RequestReport GetIzvjestajSenzora(RequestReport requestReport)
        //{
        //    RequestReport izvjestajSenzora = new RequestReport();


        //    foreach (var row in database.Uredjaji)
        //    {
        //        if (row.Lokacija == mjesto)
        //        {

        //        }
        //    }

        //    izvjestajSenzora.MjestoSenzora = mjesto;
        //    izvjestajSenzora.ImeSenzora = ime;
        //    izvjestajSenzora.VrijemeOd = vrijemeOd;
        //    izvjestajSenzora.VrijemeDo = vrijemeDo;

        //    return izvjestajSenzora;
        //}

        //public IzvjestajSenzora vratiIzvjestaj()
        //{
        //    IzvjestajSenzora izvjestajSenzora = new IzvjestajSenzora();
        //    izvjestajSenzora.ImeSenzora = senzor.ImeSenzora;
        //    izvjestajSenzora.MjestoSenzora = uredjaj.Lokacija;
        //}
    }
}
