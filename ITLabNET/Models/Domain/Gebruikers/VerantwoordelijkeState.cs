﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
    [NotMapped]
    public class VerantwoordelijkeState : GebruikerProfielState
    {
        #region Constructors
        public VerantwoordelijkeState()
        {

        }

        public VerantwoordelijkeState(Gebruiker gebruiker) : base(gebruiker)
        {

        }
        #endregion

        #region Methods
        public string getProfiel() { return "verantwoordelijke"; }
        #endregion
    }
}
