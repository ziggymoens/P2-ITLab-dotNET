using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
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
        public override string getProfiel() { return "geblokkeerd"; }
        #endregion
    }
}
