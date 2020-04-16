using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaApp.Application.Common
{
    public class Mjerenje
    {
        public int Id { get; set; }
        public DateTime VrijemeMjerenja { get; set; }
        public string MinVrijednost { get; set; }
        public string MaxVrijednost { get; set; }
        public string Alarm { get; set; }
        public string VrijednostMjerenja { get; set; }
        public string ValidnostMjeranja { get; set; }
    }
}
