using ITLabNET.Models.Domain.Sessies;
using System;
using System.Collections.Generic;

namespace ITLabNET.Models.Domain
{
    public class Academiejaar
    {
        #region Fields
        private int _academiejaar;
        private ICollection<Sessie> _sessies;
        private DateTime? _start;
        private DateTime? _eind;
        private string _academiejaarString;
        private string _startString;
        private string _eindString;
        private int _aantal;
        #endregion

        #region Properties
        public int AcademieJaar
        {
            get
            {
                return _academiejaar;
            }
            set
            {
                if (value < 2000 || value > 3000)
                    throw new ArgumentException("Academiejaar moet na 2000 zijn en voor 3000");
                _academiejaar = value;
            }
        }

        public DateTime? Start
        {
            get
            {
                return _start;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("Starttijdstip moet ingevuld zijn");
                _start = value;
            }
        }

        public DateTime? Eind
        {
            get
            {
                return _eind;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("Eindtijdstip moet ingevuld zijn");
                _eind = value;
            }
        }

        public int Aantal
        {
            get
            {
                return _aantal;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Aantal mag niet onder nul liggen");
                _aantal = value;
            }
        }
        #endregion

        #region constructors
        public Academiejaar() { }

        public Academiejaar(int academiejaar, DateTime start, DateTime eind)
        {
            AcademieJaar = academiejaar;
            Start = start;
            Eind = eind;
        }
        #endregion
    }
}