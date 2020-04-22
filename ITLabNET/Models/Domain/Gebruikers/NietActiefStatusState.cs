using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
    [NotMapped]
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
        public string getProfiel() { return "niet actief"; }
        #endregion
    }
}
