using Irma.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Irma
{
    public class XMLContext : DbContext
    {
        public XMLContext(DbContextOptions<XMLContext> options)
            : base(options)
        {
        }

        public DbSet<XMLDoc> XMLDocs { get; set; }
    }
}
