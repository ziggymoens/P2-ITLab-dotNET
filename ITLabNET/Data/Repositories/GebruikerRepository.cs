using ITLabNET.Models.Domain.Gebruikers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly ApplicationDbContext _context;

        public GebruikerRepository(ApplicationDbContext context)
        {
            this._context = context;

        }
        public Gebruiker GetByBarCode(long barCode)
        {
            return _context.Gebruikers.FirstOrDefault(e => e.Barcode == barCode);
        }

        public Gebruiker GetByGebruikersnaam(string userName)
        {
            return _context.Gebruikers.FirstOrDefault(e => e.Gebruikersnaam.Equals(userName));
        }

        public Gebruiker GetByNaam(string naam)
        {
            return _context.Gebruikers.FirstOrDefault(e => e.Naam.Equals(naam));
        }

        public void SaveChanges()
        {
           _context.SaveChanges();
        }
    }
}
