using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Sessies
{
    public abstract class SessieState
    {
        #region Fields
        private int _statusId;
        protected Sessie _sessie;
        #endregion

        #region Properties
        public int StatusId { get; set; }
        public Sessie Sessie
        {
            get { return _sessie; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Gebruiker mag niet null zijn");
            }
        }
        #endregion

        #region Constructors
        public SessieState()
        {

        }

        public SessieState(Sessie sessie)
        {
            _sessie = sessie;
        }
        #endregion

        #region Methods
        public abstract string getState();
        #endregion
    }
}
