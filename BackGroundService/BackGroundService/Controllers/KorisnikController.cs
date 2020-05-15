using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackGroundService.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService service;

        public KorisnikController(IKorisnikService service)
        {
            this.service=service;
        }

        [HttpPost("postKorisnika")]
        public async Task<ActionResult<Korisnik>> PostKorisnika(Korisnik korisnik)
        {
            service.dodajKorisnika(korisnik);
            return korisnik;
        }

        //[HttpGet("getKorisnici")]
        //public IEnumerable<Korisnik> Get()
        //{
            
        //}

    }


}