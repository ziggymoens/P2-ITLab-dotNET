﻿using ITLabNET.Models.Domain.Gebruikers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Data.Repositories
{
    public class GebruikerRepistory : IGebruikerRepository
    {
        public Gebruiker GetByBarCode(long barCode)
        {
            throw new NotImplementedException();
        }

        public Gebruiker GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Gebruiker GetByGebruikersNaam(string userName)
        {
            throw new NotImplementedException();
        }

        public Gebruiker GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Gebruiker GetByNaam(string naam)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
