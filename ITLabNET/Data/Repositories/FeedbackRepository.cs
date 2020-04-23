using ITLabNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Data.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _context.Feedbacks.ToList();
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
