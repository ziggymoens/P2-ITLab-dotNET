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
        private string _naam;
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
        public string naam {
            get { return _naam; }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Naam mag niet leeg zijn");
                }
                _naam = value;
            }
        }
        #endregion
    }
}
