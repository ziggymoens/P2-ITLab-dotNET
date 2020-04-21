using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Sessies
{
    public abstract class SessieState
    {
        #region Fields
        private int Id;
        protected Sessie _sessie;
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
