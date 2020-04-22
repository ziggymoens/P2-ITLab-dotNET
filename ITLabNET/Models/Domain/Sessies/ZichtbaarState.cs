using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Sessies
{
    [NotMapped]
    public class ZichtbaarState : SessieState
    {
        #region Constructors
        public ZichtbaarState()
        {

        }

        public ZichtbaarState(Sessie sessie) : base(sessie)
        {

        }
        #endregion

        #region Methods
        public string getState()
        {
            return "zichtbaar";
        }
        #endregion
    }
}
