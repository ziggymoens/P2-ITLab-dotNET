using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Sessies
{
    public class NietZichtbaarState : SessieState
    {
        public NietZichtbaarState()
        {

        }

        public NietZichtbaarState(Sessie sessie) : base(sessie)
        {

        }

        public override string getState()
        {
            return "niet zichtbaar";
        }
    }
}
