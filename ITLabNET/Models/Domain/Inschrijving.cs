using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain
{
    public class Inschrijving
    {
        #region Fields
        private string _inschrijvingsId;
        private Gebruiker _gebruiker;
        private Sessie _sessie;
        private DateTime? _inschrijvingsdatum;
        private bool _statusAanwezigheid = false;
        private bool _verwijderd;
        #endregion

        #region Properties
        public string InschrijvingsId
        {
            get { return _inschrijvingsId; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("InschrijvingsId mag niet null of leeg zijn");
                _inschrijvingsId = value;
            }
        }

        public Gebruiker Gebruiker
        {
            get { return _gebruiker; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Gebruiker mag niet null zijn");
                _gebruiker = value;
            }
        }

        public Sessie Sessie
        {
            get { return _sessie; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Sessie mag niet null zijn");
                _sessie = value;
            }
        }

        public DateTime? InschrijvingsDatum
        {
            get { return _inschrijvingsdatum; }
            set
            {
                if (value == null)
                    throw new ArgumentException("InschrijvingsDatum mag niet null zijn");
                _inschrijvingsdatum = value;
            }
        }

        public bool StatusAanwezigheid
        {
            get { return _statusAanwezigheid; }
            set { _statusAanwezigheid = value; }
        }

        public bool Verwijderd
        {
            get { return _verwijderd; }
            set { _verwijderd = value; }
        }
        #endregion

        #region constructors
        public Inschrijving(Gebruiker gebruiker, Sessie sessie)
        {
            Gebruiker = gebruiker;
            Sessie = sessie;
        }
        #endregion
    }
}
