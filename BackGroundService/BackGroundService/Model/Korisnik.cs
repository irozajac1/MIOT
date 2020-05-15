using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackGroundService
{
    public class Korisnik
    {
        public Guid ID { get; set; }
        public string Ime { get; set; }
        public String Prezime { get; set; }
        public int Godine { get; set; }
    }
}
