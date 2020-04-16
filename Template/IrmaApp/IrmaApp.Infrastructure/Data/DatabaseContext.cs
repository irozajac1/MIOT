using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaApp.Infrastructure.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Mjerenje> Mjerenja { get; set; }
        public DbSet<Senzor> Senzori { get; set; }
        public DbSet<Uredjaj> Uredjaji { get; set; }
        public DbSet<XMLDoc> XMLDocs { get; set; }
    }
}
