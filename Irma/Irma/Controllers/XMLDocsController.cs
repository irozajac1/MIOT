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

namespace Irma.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class XMLDocsController : ControllerBase
    {
        private readonly XMLContext _context;
        private readonly XMLService service;
        static readonly HttpClient client = new HttpClient();

        public XMLDocsController(XMLContext context)
        {
            _context = context;
        }

        // GET: api/XMLDocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<XMLDoc>>> GetXMLDocs()
        {
            var obj = await _context.XMLDocs.ToListAsync();
            return obj;
        }

        [HttpGet("proba")]
        public void GetDocument()
        {
            service.GetXML();
        }

        // GET: api/XMLDocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<XMLDoc>> GetXMLDoc(long id)
        {
            var xMLDoc = await _context.XMLDocs.FindAsync(id);

            if (xMLDoc == null)
            {
                return NotFound();
            }

            return xMLDoc;
        }

        // PUT: api/XMLDocs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutXMLDoc(long id, XMLDoc xMLDoc)
        {
            if (id != xMLDoc.Id)
            {
                return BadRequest();
            }

            _context.Entry(xMLDoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XMLDocExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/XMLDocs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<XMLDoc>> PostXMLDoc(XMLDoc xMLDoc)
        {
            _context.XMLDocs.Add(xMLDoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetXMLDoc", new { id = xMLDoc.Id }, xMLDoc);
        }

        // DELETE: api/XMLDocs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<XMLDoc>> DeleteXMLDoc(long id)
        {
            var xMLDoc = await _context.XMLDocs.FindAsync(id);
            if (xMLDoc == null)
            {
                return NotFound();
            }

            _context.XMLDocs.Remove(xMLDoc);
            await _context.SaveChangesAsync();

            return xMLDoc;
        }

        private bool XMLDocExists(long id)
        {
            return _context.XMLDocs.Any(e => e.Id == id);
        }
    }
}
