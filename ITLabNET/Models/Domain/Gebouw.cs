using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain
{
    [NotMapped]
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
                    throw new ArgumentException("Campus mag niet null zijn");
                _campus = value;
            }
        }
        #endregion
    }
}
