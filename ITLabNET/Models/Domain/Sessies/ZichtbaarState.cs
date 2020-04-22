﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Sessies
{
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
        public override string getState()
        {
            return "zichtbaar";
        }
        #endregion
    }
}
