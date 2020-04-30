using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain
{
    
    public class Stad
    {
        #region Fields
        public int _stadId;
        private int _postcode;
        private string _naam;
        #endregion

        #region Properties
        public int StadId { get => _stadId; set { _stadId = value; } }
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
        public string Naam
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

        #region constructors
        public Stad(int postcode, string naam)
        {
            Postcode = postcode;
            Naam = naam;
        }
        #endregion
    }
}