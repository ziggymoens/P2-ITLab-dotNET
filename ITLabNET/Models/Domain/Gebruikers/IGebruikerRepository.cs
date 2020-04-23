using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
    public interface IGebruikerRepository
    {
        Gebruiker GetByGebruikersNaam(string userName);
        Gebruiker GetByEmail(string email);
        Gebruiker GetByNaam(string naam);
        Gebruiker GetById(int id);
        Gebruiker GetByBarCode(long barCode);
        void SaveChanges();
    }
}
