using Irma.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Irma.Context
{
    public class DatabaseContext : DbContext
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
