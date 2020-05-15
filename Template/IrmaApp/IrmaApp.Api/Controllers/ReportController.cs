using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IrmaApp.Core.Entity;
using IrmaApp.Core.Interface;
using IrmaApp.Core.Model.Request;
using IrmaApp.Core.Model.Response;
using IrmaApp.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IrmaApp.Api.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("getSenzor")]
        public List<ResponseReport> GetSenzorByName(RequestReport report)
        {
            List<Senzor> Senzori = _reportService.GetReportBySenzorName(report);
            List<SenzorDTO> SenzorDTOs = _reportService.GetReportBySenzorNameDTO(Senzori);
            return _reportService.GenerateMeasurementRepot(SenzorDTOs);
        }
    }
}