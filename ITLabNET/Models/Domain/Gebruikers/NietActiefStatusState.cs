using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
    public class NietActiefStatusState : GebruikerStatusState
    {
        #region Constructors
        public NietActiefStatusState()
        {

        }

        public NietActiefStatusState(Gebruiker gebruiker) : base(gebruiker)
        {

        }
        #endregion

        #region Methods
        public override string getProfiel() { return "niet actief"; }
        #endregion
    }
}
