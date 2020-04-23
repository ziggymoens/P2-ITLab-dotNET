using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetAll();
        IEnumerable<Feedback> GetByKeyword(string tekst);
        IEnumerable<Feedback> GetByGebruiker(string naam);
        void Add(Feedback feedback);
        void SaveChanges();

    }
}
