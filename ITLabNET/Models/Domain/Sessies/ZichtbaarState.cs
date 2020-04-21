using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Sessies
{
    public class ZichtbaarState : SessieState
    {
        public ZichtbaarState()
        {

        }

        public ZichtbaarState(Sessie sessie) : base(sessie)
        {

        }

        public override string getState()
        {
            return "zichtbaar";
        }
    }
}
