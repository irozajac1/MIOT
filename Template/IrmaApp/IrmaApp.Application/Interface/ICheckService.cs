using IrmaApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace IrmaApp.Core.Interface
{
    public interface ICheckService
    {
        bool ProvjeraSenzora(XmlNode senzor, int j);
        bool ProvjeraUredjaja(XmlNode uredjaj);
        Uredjaj NadjiUredjaj(int id);

    }
}
