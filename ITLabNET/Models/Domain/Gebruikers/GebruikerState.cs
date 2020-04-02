﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
    public class GebruikerState : GebruikerProfielState
    {
        #region Constructors
        public GebruikerState()
        {

        }

        public GebruikerState(Gebruiker gebruiker) : base(gebruiker)
        {

        }
        #endregion

        #region Methods
        public override string getProfiel() { return "gebruiker"; }
        #endregion
    }
}
