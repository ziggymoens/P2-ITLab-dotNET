using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain
{
    [NotMapped]
    public class Campus
    {
        #region Fields
        private Stad _stad;
        private string _naam;
        #endregion

        #region Properties
        public Stad Stad
        {
            get { return _stad; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Stad mag niet minder dan 0 zijn");
                _stad = value;
            }
        }
        public string naam
        {
            get { return _naam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Naam mag niet leeg zijn");
                }
                _naam = value;
            }
        }
        #endregion
    }
}