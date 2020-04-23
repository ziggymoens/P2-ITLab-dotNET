using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Sessies
{
    public class GeslotenState : SessieState
    {
        #region Constructors
        public GeslotenState()
        {

        }

        public GeslotenState(Sessie sessie) : base(sessie)
        {

        }
        #endregion

        #region Methods
        public override string getState()
        {
            return "gesloten";
        }
        #endregion
    }
}
