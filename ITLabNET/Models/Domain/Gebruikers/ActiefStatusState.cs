using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
    public class ActiefStatusState : GebruikerStatusState
    {
        #region Constructors
        public ActiefStatusState()
        {

        }

        public ActiefStatusState(Gebruiker gebruiker) : base(gebruiker)
        {

        }
        #endregion

        #region Methods
        public override string getProfiel() { return "actief"; }
        #endregion
    }
}
