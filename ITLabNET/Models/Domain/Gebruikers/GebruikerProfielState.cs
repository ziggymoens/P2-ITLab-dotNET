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

        #region Properties
        public int ProfielId
        {
            get { return _profielId; }
            set { _profielId = value; }
        }
        public Gebruiker Gebruiker
        {
            get { return _gebruiker; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Gebruiker mag niet null zijn");
            }
        }
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
