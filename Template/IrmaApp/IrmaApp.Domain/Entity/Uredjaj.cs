﻿using IrmaApp.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaApp.Domain.Entity
{
    public class Uredjaj
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string Lokacija { get; set; }
        public List<Senzor> Senzori { get; set; }
    }
}
