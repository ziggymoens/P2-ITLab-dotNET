using ITLabNET.Models.Domain;
using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Data.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly DbSet<Feedback> _feedbacks;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
            _feedbacks = context.Feedbacks;
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _context.Feedbacks.ToList();
        }

        public IEnumerable<Feedback> GetBySessie(Sessie sessie) {
            return _feedbacks
                .Include(e => e.Gebruiker)
                .Where(e => e.Sessie == sessie);
        }

        public IEnumerable<Feedback> GetByGebruiker(string naam)
        {
            return _context.Feedbacks.Where(f => f.Gebruiker.Naam.Equals(naam));
        }

        public IEnumerable<Feedback> GetByKeyword(string tekst)
        {
            return _context.Feedbacks.Where(f => f.Tekst.Contains(tekst)).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Add(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
        }
    }
}
