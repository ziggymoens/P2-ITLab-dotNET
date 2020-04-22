using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain
{
    [NotMapped]
    public class Stad
    {
        #region Fields
        private int _postcode;
        #endregion

        #region Properties
        public int Postcode
        {
            get { return _postcode; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Postcode mag niet minder dan 0 zijn");
                _postcode = value;
            }
        }
        #endregion
    }
}