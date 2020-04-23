using ITLabNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Data.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public void Add(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetByGebruiker(string naam)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetByKeyword(string tekst)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
