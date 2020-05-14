using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IrmaApp.Core.Interface;
using IrmaApp.Core.Model.Response;

namespace IrmaApp.Api.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class XMLDocsController : ControllerBase
    {
        private readonly IXMLService _service;
        //private ReportService _reportService;

        public XMLDocsController(IXMLService ixmlService, ReportService reportService)
        {
            _service = ixmlService;
            //_reportService = reportService;

        }

        [HttpGet("getXML")]
        public IActionResult GetDocument()
        {
            _service.getXmlDocument();
            return Ok();
        }

        //[HttpGet("getSenzor")]
        //public String getVrijednostiSenzora()
        //{
        //    return _reportService.GetReportBySenzorName(new Core.Model.Request.RequestReport());
        //}
    }
}