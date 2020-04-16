using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaApp.Application.Common
{
    public class Senzor
    {
        public int Id { get; set; }
        public int SenzorId { get; set; }
        public string ImeSenzora { get; set; }
        public string TipSenzora { get; set; }
        public List<Mjerenje> Mjerenja { get; set; }
    }
}
