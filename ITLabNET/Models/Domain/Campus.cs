using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain
{
    
    public class Campus
    {
        #region Fields
        public int _campusId;
        //private Stad _stad;
        private string _naam;
        #endregion

        #region Properties
        public int CampusId { get => _campusId; set { _campusId = value; } }
       /* public Stad Stad
        {
            get { return _stad; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Stad mag niet minder dan 0 zijn");
                _stad = value;
            }
        }*/
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
        public Campus()
        {

        }
        public Campus(/*Stad stad, */string naam)
        {
           /* Stad = stad;*/
            Naam = naam;
        }
        #endregion
    }
}
