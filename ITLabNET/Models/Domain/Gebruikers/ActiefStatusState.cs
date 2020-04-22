using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
    [NotMapped]
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
        public string getProfiel() { return "actief"; }
        #endregion
    }
}
