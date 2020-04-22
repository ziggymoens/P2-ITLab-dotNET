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
        private string _type;
        #endregion

        #region Properties
        public string LokaalCode
        {
            get { return _lokaalCode; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("LokaalCode mag niet null of leeg zijn");
                _lokaalCode = value;
            }
        }

        public int AantalPlaatsen
        {
            get { return _aantalPlaatsen; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("AantalPlaatsen mag niet minder dan 0 zijn");
            }
        }

        public bool Verwijderd
        {
            get { return _verwijderd; }
            set { _verwijderd = value; }
        }

        public Gebouw Gebouw
        {
            get { return _gebouw; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Gebouw mag niet null zijn");
                _gebouw = value;
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Type mag niet null of leeg zijn");
                _type = value;
            }
        }
        #endregion

        #region Constructor
        public Lokaal(string lokaalCode, string type, int aantalPlaatsen)
        {
            LokaalCode = lokaalCode;
            Type = type;
            AantalPlaatsen = aantalPlaatsen;
        }
        #endregion
    }
}
