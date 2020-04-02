using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
    public abstract class GebruikerStatusState
    {
        #region Fields
        private int _statusId;
        protected Gebruiker _gebruiker;
        #endregion

        #region Constructors
        public GebruikerStatusState()
        {

        }

        public GebruikerStatusState(Gebruiker gebruiker)
        {
            _gebruiker = gebruiker;
        }
        #endregion

        #region Methods
        public abstract string getProfiel();
        #endregion
    }
}
