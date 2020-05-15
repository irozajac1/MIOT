using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackGroundService
{
    public class DbTestContext : DbContext
    {
        public DbTestContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Korisnik> Korisnici { get; set; }
    }
}
