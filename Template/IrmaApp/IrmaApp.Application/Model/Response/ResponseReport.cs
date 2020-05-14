using IrmaApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaApp.Core.Model.Response
{
    public class ResponseReport
    {
        public SenzorDTO Mjerenje { get; set; }
        public String Poruka { get; set; }
    }
}
