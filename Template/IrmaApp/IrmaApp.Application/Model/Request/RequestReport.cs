using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaApp.Core.Model.Request
{
    public class RequestReport
    {
        public string MjestoSenzora { get; set; }
        public string ImeSenzora { get; set; }
        public DateTime VrijemeOd { get; set; }
        public DateTime VrijemeDo { get; set; }

    }
}
