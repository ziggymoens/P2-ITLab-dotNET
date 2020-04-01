using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain
{
    public class Lokaal
    {
        #region Fields
        private string _lokaalCode;
        private int _aantalPlaatsen;
        private bool _verwijderd = false;
        private Gebouw _gebouw;
        private string type;
        #endregion
    }
}
