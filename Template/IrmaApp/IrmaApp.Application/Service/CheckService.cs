using IrmaApp.Core.Entity;
using IrmaApp.Core.Interface;
using IrmaApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IrmaApp.Core.Service
{
    public class CheckService : ICheckService
    {
        private readonly DatabaseContext context;

        public CheckService(DatabaseContext context)
        {
            this.context = context;
        }

        public bool ProvjeraSenzora(XmlNode senzor, int j)
        {
            var _senzor = context.Senzori.FirstOrDefault(x => x.SenzorId == int.Parse(senzor.ChildNodes[j].Attributes[0].InnerText));
            if (_senzor == null)
                return false;

            return true;
            
        }

        public bool ProvjeraUredjaja(XmlNode uredjaj)
        {
            var _uredjaj = context.Uredjaji.FirstOrDefault(x => x.DeviceId == int.Parse(uredjaj.Attributes[0].InnerText));
            if (_uredjaj != null) return true;

            return false;
        }

        public Uredjaj NadjiUredjaj(int id)
        {
            return context.Uredjaji.FirstOrDefault(x => x.DeviceId == id);
        }
    }
}
