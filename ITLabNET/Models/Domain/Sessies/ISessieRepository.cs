﻿using ITLabNET.Models.Domain.Gebruikers;
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
        IEnumerable<Sessie> GetByZichtbaarStatus();
        IEnumerable<Sessie> GeefAanwezigeSessiesGebruiker(Gebruiker g);
        IEnumerable<Sessie> GetByVerantwoordelijke(Gebruiker g);
        Sessie GetById(string id);
        void SaveChanges();
    }
}
