using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
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
        public override string getProfiel() { return "verantwoordelijke"; }
        #endregion
    }
}
