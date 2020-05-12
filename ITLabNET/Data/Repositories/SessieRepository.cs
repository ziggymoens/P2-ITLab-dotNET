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

        public IEnumerable<Sessie> GetAll()
        {
            return _sessies
                .Include(s => s.Academiejaar)
                .Include(s => s.Verantwoordelijke)
                .Include(s => s.Inschrijvingen).ThenInclude(e => e.Gebruiker)
                .Include(s => s.Lokaal).ThenInclude(l => l.Campus)
                .Include(s => s.Lokaal).ThenInclude(l => l.Stad)
                .Include(s => s.Lokaal).ThenInclude(l => l.Gebouw)
                .OrderBy(s => s.Datum).ThenBy(s => s.StartUur).AsNoTracking().ToList();
        }

        public Sessie GetById(int id)
        {
            return _sessies
                .Include(e => e.Lokaal).ThenInclude(l => l.Gebouw)
                .Include(e => e.Lokaal).ThenInclude(l => l.Campus)
                .Include(e => e.Lokaal).ThenInclude(l => l.Stad)
                .Include(s => s.Verantwoordelijke)
                .Include(s => s.Inschrijvingen)
                .Include(a => a.Academiejaar)
                .SingleOrDefault(s => s.SessieId.Equals(id));
        }

        public IEnumerable<Sessie> GetByOpenStatus(bool IsOpen)
        {
            return _sessies.Where(s => s.CurrentState == SessieStates.Open);
        }

        public IEnumerable<Sessie> GetByZichtbaarStatus(Gebruiker? g)
        {
            IEnumerable<Sessie> sessies;
            if (g == null) {
                sessies =  _sessies
                    .Include(s => s.Academiejaar)
                    .Include(s => s.Verantwoordelijke)
                    .Include(s => s.Inschrijvingen).ThenInclude(e => e.Gebruiker)
                    .Include(s => s.Lokaal).ThenInclude(l => l.Campus)
                    .Include(s => s.Lokaal).ThenInclude(l => l.Stad)
                    .Include(s => s.Lokaal).ThenInclude(l => l.Gebouw)
                    .Where(s => s.CurrentState == SessieStates.Zichtbaar)
                    .OrderBy(s => s.Datum).ThenBy(s => s.StartUur).AsNoTracking().ToList();
            }
            else {
                sessies = _sessies
                .Include(s => s.Academiejaar)
                .Include(s => s.Verantwoordelijke)
                .Include(s => s.Inschrijvingen).ThenInclude(e => e.Gebruiker)
                .Include(s => s.Lokaal).ThenInclude(l => l.Campus)
                .Include(s => s.Lokaal).ThenInclude(l => l.Stad)
                .Include(s => s.Lokaal).ThenInclude(l => l.Gebouw)
                .Where(s => s.Verantwoordelijke == g)
                .Where(s => s.CurrentState == SessieStates.Zichtbaar)
                .OrderBy(s => s.Datum).ThenBy(s => s.StartUur).AsNoTracking().ToList();
            }
            return sessies;
        }

        public IEnumerable<Sessie> GetFeedbackOpties(Gebruiker g)
        {
            return _sessies
                .Include(s => s.Verantwoordelijke)
                .Where(e => e.CurrentState == SessieStates.Gesloten)
                .Where(s => s.Inschrijvingen.Any(i => i.Gebruiker == g));
        }

        public IEnumerable<Sessie> GetOpenbareSessies(Gebruiker g)
        {
            return _sessies
                .Include(s => s.Inschrijvingen).ThenInclude(e => e.Gebruiker)
                .Include(s => s.Lokaal).ThenInclude(l => l.Campus)
                .Include(s => s.Lokaal).ThenInclude(l => l.Stad)
                .Include(s => s.Lokaal).ThenInclude(l => l.Gebouw)
                .Where(s => s.Verantwoordelijke == g)
                .Where(s => s.CurrentState == SessieStates.Zichtbaar)
                .Where(s => s.Datum.Date == DateTime.Now.Date)
                .OrderBy(s => s.Datum).ThenBy(s => s.StartUur).AsNoTracking().ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
