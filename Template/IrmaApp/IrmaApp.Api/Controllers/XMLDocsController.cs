using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IrmaApp.Core.Interface;

namespace IrmaApp.Api.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class XMLDocsController : ControllerBase
    {
        private readonly IXMLService _service;

        public XMLDocsController(IXMLService ixmlService)
        {
            _service = ixmlService;

        }

        [HttpGet("getXML")]
        public String GetDocument()
        {
           return _service.getXmlDocument();
        }
    }
}