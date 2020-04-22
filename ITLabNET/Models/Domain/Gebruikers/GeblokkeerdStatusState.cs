using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
    [NotMapped]
    public class GeblokkeerdStatusState : GebruikerStatusState
    {
        #region Constructors
        public GeblokkeerdStatusState()
        {

        }

        public GeblokkeerdStatusState(Gebruiker gebruiker) : base(gebruiker)
        {

        }
        #endregion

        #region Methods
        public string getProfiel() { return "geblokkeerd"; }
        #endregion
    }
}
