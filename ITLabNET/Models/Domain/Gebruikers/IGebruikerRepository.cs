using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
    public interface IGebruikerRepository
    {
        Gebruiker GetByGebruikersnaam(string userName);
        Gebruiker GetByNaam(string naam);
        Gebruiker GetByBarCode(long barCode);
        void SaveChanges();
    }
}
