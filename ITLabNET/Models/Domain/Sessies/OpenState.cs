using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Sessies
{
    public class OpenState : SessieState
    {
        public OpenState()
        {

        }

        public OpenState(Sessie sessie) : base(sessie)
        {

        }

        public override string getState()
        {
            return "open";
        }
    }
}
