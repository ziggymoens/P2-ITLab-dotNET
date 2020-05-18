using ITLabNET.Models.Domain.Gebruikers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Sessies
{
    public interface ISessieRepository
    {
        IEnumerable<Sessie> GetAll();
        IEnumerable<Sessie> GetByOpenStatus(bool IsOpen);
        IEnumerable<Sessie> GetByZichtbaarStatus(Gebruiker? g);
        IEnumerable<Sessie> GetOpenbareSessies(Gebruiker g);
        IEnumerable<Sessie> GetFeedbackOpties(Gebruiker g);
        Sessie GetById(int id);
        void SaveChanges();
    }
}
