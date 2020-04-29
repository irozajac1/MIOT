using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaApp.Core.Entity
{
    public class Uredjaj
    {
        public Guid Id { get; set; }
        public int DeviceId { get; set; }
        public string Lokacija { get; set; }
        public List<Senzor> Senzori { get; set; }
    }
}
