using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Sessies
{
    public class NietZichtbaarState : SessieState
    {
        #region Constructors
        public NietZichtbaarState()
        {

        }

        public NietZichtbaarState(Sessie sessie) : base(sessie)
        {

        }
        #endregion

        #region Methods
        public  override string getState()
        {
            return "niet zichtbaar";
        }
        #endregion
    }
}
