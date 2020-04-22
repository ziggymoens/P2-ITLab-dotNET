using ITLabNET.Models.Domain.Gebruikers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Sessies
{
    public class Sessie
    {
        #region Fields
        private string _titel;
        private string _naamGastspreker;
        private DateTime _datum;
        private string _datumString;
        private DateTime _startSessie;
        private DateTime _startUur;
        private DateTime _eindeUur;
        private int _maximumAantalPlaatsen;
        private string _beschrijving;
        private int _aantalAanwezigen;
        private string _stad;
        private Academiejaar _academiejaar;
        private bool _verwijderd;
        private ICollection<Media> _media;
        private ICollection<Inschrijving> _inschrijvingen;
        private ICollection<Aankondiging> _aankondigingen;
        private ICollection<Feedback> _feedback;
        private Lokaal _lokaal;
        private Gebruiker _verantwoordelijke;
        private SessieState _currentState;
        #endregion

        #region Properties
        public string sessieId { get; set; }

        public string Titel
        {
            get => _titel;
            set
            {
                _titel = value;
            }
        }

        public string NaamGastSpreker
        {
            get => _naamGastspreker;
            set
            {
                _naamGastspreker = value;
            }
        }

        public DateTime Datum
        {
            get => _datum;
            set
            {
                _datum = value;
            }
        }

        public string DatumString
        {
            get => _datumString;
            set
            {
                _datumString = value;
            }
        }

        public DateTime StartSessie
        {
            get => _startSessie;
            set
            {
                _startSessie = value;
            }
        }

        public DateTime StartUur
        {
            get => _startUur;
            set
            {
                _startUur = value;
            }
        }

        public DateTime EindeUur
        {
            get => _eindeUur;
            set
            {
                _eindeUur = value;
            }
        }

        public int MaximumAantalPlaatsen
        {
            get => _maximumAantalPlaatsen;
            set
            {
                _maximumAantalPlaatsen = value;
            }
        }

        public string Beschrijving
        {
            get => _beschrijving;
            set
            {
                _beschrijving = value;
            }
        }

        public string Stad
        {
            get => _stad;
            set
            {
                _stad = value;
            }
        }

        public Academiejaar Academiejaar
        {
            get => _academiejaar;
            set
            {
                _academiejaar = value;
            }
        }

        public bool Verwijderd
        {
            get => _verwijderd;
            set
            {
                _verwijderd = value;
            }
        }

        public ICollection<Media> Media
        {
            get => _media;
            set
            {
                _media = value;
            }
        }

        public ICollection<Inschrijving> Inschrijvingen
        {
            get => _inschrijvingen;
            set
            {
                _inschrijvingen = value;
            }
        }

        public ICollection<Aankondiging> Aankondigingen
        {
            get => _aankondigingen;
            set
            {
                _aankondigingen = value;
            }
        }

        public ICollection<Feedback> Feedback
        {
            get => _feedback;
            set
            {
                _feedback = value;
            }
        }

        public Lokaal Lokaal
        {
            get => _lokaal;
            set
            {
                _lokaal = value;
            }
        }

        public Gebruiker Verantwoordelijke
        {
            get => _verantwoordelijke;
            set
            {
                _verantwoordelijke = value;
            }
        }
        public SessieState CurrentState { get => _currentState; }

        public void setSessieState(string status)
        {
            if (status == null || string.IsNullOrEmpty(status))
            {
                throw new ArgumentException("Sessie state mag niet leeg of null zijn");
            }
            switch (status)
            {
                case "open":
                    toState(new OpenState(this));
                    break;
                case "gesloten":
                    toState(new GeslotenState(this));
                    break;
                case "zichtbaar":
                    toState(new ZichtbaarState(this));
                    break;
                default:
                case "niet zichtbaar":
                    toState(new NietZichtbaarState(this));
                    break;
            }
        }
        #endregion

        #region Methods
        public void toState(SessieState sessieState) { _currentState = sessieState; }
        #endregion
    }
}
