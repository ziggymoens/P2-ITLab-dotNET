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
        protected Sessie sessie;
        #endregion
    }
}
