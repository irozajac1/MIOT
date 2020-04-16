using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Irma.Models
{
    public class Uredjaj
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string Lokacija { get; set; }
        public List<Senzor> Senzori { get; set; }
    }
}

//Ienumerable