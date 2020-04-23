using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Data.Repositories
{
    public class SessieRepository : ISessieRepository
    {
        public IEnumerable<Sessie> GeefAanwezigeSessiesGebruiker(Gebruiker g)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sessie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Sessie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sessie> GetByOpenStatus(bool IsOpen)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sessie> GetByVerantwoordelijke(Gebruiker g)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sessie> GetByZichtbaarStatus()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
