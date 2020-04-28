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
        private int _sessieId;
        private string _titel;
        private string _naamGastspreker;
        private DateTime _datum;
        private DateTime _startUur;
        private DateTime _eindeUur;
        private int _maximumAantalPlaatsen;
        private string _beschrijving;
        private int _aantalAanwezigen;
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
        public int SessieId 
        {
            get => _sessieId; 
            set
            {
                _sessieId = value;
            }
        }

        public string Titel
        {
            get => _titel;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Titel mag niet leeg zijn");
                }
                else
                {
                    _titel = value;
                }
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
                if (value < DateTime.Now.AddDays(1))
                {
                    throw new ArgumentException("Datum moet minstens één dag in de toekomst liggen");
                }
                _datum = value.Date;
            }
        }

        public DateTime StartUur
        {
            get => _startUur;
            set
            {
                if (value == DateTime.MinValue)
                {
                    throw new ArgumentException("Datum en uur mogen niet leeg zijn");
                }
                _startUur = value;
                Datum = value;
            }
        }

        public DateTime EindeUur
        {
            get => _eindeUur;
            set
            {
                if (value == DateTime.MinValue)
                {
                    throw new ArgumentException("Eind datum mag niet leeg zijn");
                }
                if (value.Date != Datum.Date)
                {
                    throw new ArgumentException("Begin en eind datum moeten gelijk zijn");
                }
                /*if (StartUur.AddMinutes(29).AddSeconds(59).AddMilliseconds(99) < value)
                {
                    throw new ArgumentException("Een sessie moet minimaal 30 minuten duren");
                }*/
                _eindeUur = value;
            }
        }

        public int MaximumAantalPlaatsen
        {
            get => _maximumAantalPlaatsen;
            set
            {
                if (Lokaal.AantalPlaatsen < value) {
                    throw new ArgumentException("Aantal plaatsen overschrijd limiet van het lokaal");
                }
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

        public Academiejaar Academiejaar
        {
            get => _academiejaar;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Academiejaar mag niet null zijn");
                }
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
                if (value == null) {
                    throw new ArgumentException("Lokaal mag niet null zijn");
                }
                _lokaal = value;
            }
        }

        public Gebruiker Verantwoordelijke
        {
            get => _verantwoordelijke;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Verantwoordelijke mag niet null zijn");
                }
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
        public Sessie()
        {

        }

        public Sessie(string titel, string beschrijving, DateTime startSessie, DateTime eindeSessie, Lokaal lokaal, Gebruiker verantwoordelijke, Academiejaar academiejaar, string state) 
        {
            Titel = titel;
            Beschrijving = beschrijving;
            StartUur = startSessie;
            EindeUur = eindeSessie;
            Lokaal = lokaal;
            Verantwoordelijke = verantwoordelijke;
            Academiejaar = academiejaar;
            setSessieState(state);
        }

        #region Methods
        public void toState(SessieState sessieState) { _currentState = sessieState; }
        #endregion
    }
}

