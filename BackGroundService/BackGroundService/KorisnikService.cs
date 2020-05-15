using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackGroundService
{
    public class KorisnikService : IKorisnikService
    {
        private readonly DbTestContext context;

        public KorisnikService(DbTestContext context)
        {
            this.context = context;
        }

        public void DajSveKorisnike()
        {
        }

        public void dodajKorisnika(Korisnik korisnik)
        {
            context.Korisnici.Add(korisnik);
            context.SaveChanges();
        }
    }
}
