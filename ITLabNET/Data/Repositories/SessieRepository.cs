using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Data.Repositories
{
    public class SessieRepository : ISessieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Sessie> _sessies;

        public SessieRepository(ApplicationDbContext context)
        {
            _context = context;
            _sessies = context.Sessies;
        }

        public IEnumerable<Sessie> GeefAanwezigeSessiesGebruiker(Gebruiker g)
        {
            return _sessies.Where(s => s.Inschrijvingen.Any(i => i.Gebruiker == g));
        }

        public IEnumerable<Sessie> GetAll()
        {
            return _sessies.Include(s => s.Academiejaar).AsNoTracking().ToList();
        }

        public Sessie GetById(string id)
        {
            return _sessies.Include(e => e.Lokaal).SingleOrDefault(s => s.SessieId.Equals(id));
        }

        public IEnumerable<Sessie> GetByOpenStatus(bool IsOpen)
        {
            return _sessies.Where(s => s.CurrentState == new OpenState());
        }

        public IEnumerable<Sessie> GetByVerantwoordelijke(Gebruiker g)
        {
            return _sessies.Where(s => s.Verantwoordelijke == g);
        }

        public IEnumerable<Sessie> GetByZichtbaarStatus()
        {
            return _sessies.Where(s => s.CurrentState == new ZichtbaarState());
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
