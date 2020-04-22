using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain
{
    public class Gebouw
    {
        #region Fields
        private Campus _campus;
        #endregion

        #region Properties
        public Campus Campus
        {
            get { return _campus; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Campuse mag niet null zijn");
                _campus = value;
            }
        }
        #endregion
    }
}
