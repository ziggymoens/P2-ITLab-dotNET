using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
    public abstract class GebruikerStatusState
    {
        #region Fields
        public int _statusId;
        protected Gebruiker _gebruiker;
        #endregion

        #region Properties
        public int StatusId { get => _statusId; set
            {
                if(value < 0)
                {
                    throw new ArgumentException("StatusId mag niet onder 0 zijn");
                }
                _statusId = value;
            } }
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
