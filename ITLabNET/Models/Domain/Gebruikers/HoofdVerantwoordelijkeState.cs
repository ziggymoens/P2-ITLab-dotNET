using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
    public class HoofdVerantwoordelijkeState : GebruikerProfielState
    {
        #region Constructors
        public HoofdVerantwoordelijkeState()
        {

        }

        public HoofdVerantwoordelijkeState(Gebruiker gebruiker) : base(gebruiker)
        {
            
        }
        #endregion

        #region Methods
        public override string getProfiel() { return "hoofdverantwoordelijke"; }
        #endregion
    }
}
