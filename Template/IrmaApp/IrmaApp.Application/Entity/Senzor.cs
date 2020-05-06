using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaApp.Core.Entity
{
    public class Senzor
    {
        public Guid Id { get; set; }
        public int SenzorId { get; set; }
        public string ImeSenzora { get; set; }
        public string TipSenzora { get; set; }
        public DateTime VrijemeMjerenja { get; set; }
        public string MinVrijednost { get; set; }
        public string MaxVrijednost { get; set; }
        public string Alarm { get; set; }
        public string VrijednostMjerenja { get; set; }
        public string ValidnostMjeranja { get; set; }
        public int UredjajId { get; set; }
        public Uredjaj Uredjaj { get; set; }
    }
}
