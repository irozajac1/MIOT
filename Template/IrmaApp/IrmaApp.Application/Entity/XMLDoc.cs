using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaApp.Core.Entity
{
    public class XMLDoc
    {
        public Guid Id { get; set; }
        public DateTime VrijemeOcitanja { get; set; }
        public String message { get; set; }
        public String messageDetails { get; set; }

    }
}
