using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain
{
    
    public class Gebouw
    {
        #region Fields
        public int _gebouwId;
        private string _naam;
        #endregion

        #region Properties
        public int GebouwId
        {
            get => _gebouwId; 
            set
            {
                _gebouwId = value;
            }
        }
  
        public string Naam {
            get { return _naam; }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Naam mag niet leeg zijn");
                }
                _naam = value;
            }
        }
        #endregion

        #region constructors
        public Gebouw()
        {

        }
        public Gebouw(string naam)
        {
            Naam = naam;
        }
        #endregion
    }
}
