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
        private bool verwijderd;
        private ICollection<Media> _media;
        private ICollection<Inschrijving> _inschrijvingen;
        private ICollection<Aankondiging> _aankondigingen;
        private ICollection<Feedback> _feedback;
        private Lokaal _lokaal;
        private Gebruiker _verantwoordelijke;
        private SessieState _currentState;
        #endregion


        public string sessieId { get; set; }
        
        public string Titel { get => _titel;
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
    }
}
