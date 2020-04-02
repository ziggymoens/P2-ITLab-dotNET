using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
    public abstract class GebruikerProfielState
    {
        #region Fields
        private int _profielId;
        protected Gebruiker _gebruiker;
        #endregion
        #region Constructors
        public GebruikerProfielState()
        {

        }

        public GebruikerProfielState(Gebruiker gebruiker)
        {
            _gebruiker = gebruiker;
        }
        #endregion

        #region Methods
        public abstract string getProfiel();
        #endregion
    }
}
