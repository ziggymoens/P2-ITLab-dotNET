using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Sessies
{
    [NotMapped]
    public class OpenState : SessieState
    {
        #region Constructors
        public OpenState()
        {

        }

        public OpenState(Sessie sessie) : base(sessie)
        {

        }
        #endregion

        #region Methods
        public  string getState()
        {
            return "open";
        }
        #endregion
    }
}
