﻿using ITLabNET.Models.Domain.Gebruikers;
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
        private SessieStates _currentState;
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
                if (value == null || string.IsNullOrEmpty(value))
                {
                    _naamGastspreker = "/";
                }
                else { _naamGastspreker = value;  }
                
            }
        }

        public DateTime Datum
        {
            get => _datum;
            set
            {
/*                if (value < DateTime.Now.AddDays(1))
                {
                    throw new ArgumentException("Datum moet minstens één dag in de toekomst liggen");
                }*/
                _datum = value.Date;
            }
        }

        public DateTime StartUur
        {
            get => _startUur;
            set
            {
/*               if (value == DateTime.MinValue)
                {
                    throw new ArgumentException("Datum en uur mogen niet leeg zijn");
                }*/
                _startUur = value;
                Datum = value;
            }
        }

        public DateTime EindeUur
        {
            get => _eindeUur;
            set
            {
/*                 if (value == DateTime.MinValue)
                {
                    throw new ArgumentException("Eind datum mag niet leeg zijn");
                }
                if (value.Date != Datum.Date)
                {
                    throw new ArgumentException("Begin en eind datum moeten gelijk zijn");
                }
                if (StartUur.AddMinutes(29).AddSeconds(59).AddMilliseconds(99) < value)
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
        public SessieStates CurrentState { get => _currentState;}

        public void setSessieState(string status)
        {
            if (status == null || string.IsNullOrEmpty(status))
            {
                throw new ArgumentException("Sessie state mag niet leeg of null zijn");
            }
            switch (status.ToLower())
            {
                case "open":
                    toState(SessieStates.Open);
                    break;
                case "gesloten":
                    if (Datum < DateTime.Now)
                    {
                        toState(SessieStates.Gesloten);
                    }
                    else {
                        throw new Exception("Een sessie kan niet gesloten worden voor de start datum.");
                    }
                    break;
                case "zichtbaar":
                    toState(SessieStates.Zichtbaar);
                    break;
                case "niet zichtbaar":
                    toState(SessieStates.NietZichtbaar);
                    break;
            }
        }
        #endregion
        public Sessie()
        {
            Media = new List<Media>();
            Inschrijvingen = new List<Inschrijving>();
            Aankondigingen = new List<Aankondiging>();
            Feedback = new List<Feedback>();
        }

        public Sessie(string titel, string beschrijving, DateTime startSessie, DateTime eindeSessie, Lokaal lokaal, int maximumAantalPlaatsen,Gebruiker verantwoordelijke,string gastspreker, Academiejaar academiejaar, string state) : this()
        {
            Titel = titel;
            Beschrijving = beschrijving;
            StartUur = startSessie;
            EindeUur = eindeSessie;
            Lokaal = lokaal;
            MaximumAantalPlaatsen = maximumAantalPlaatsen;
            Verantwoordelijke = verantwoordelijke;
            NaamGastSpreker = gastspreker;
            Academiejaar = academiejaar;
            setSessieState(state);
            init();
        }

        #region Methods
        private void init() { 
            Inschrijvingen.Add(new Inschrijving(Verantwoordelijke, this));
        }
        public void toState(SessieStates sessieState) {
            _currentState = sessieState; 
        }

        public void AddInschrijving(Gebruiker gebruiker)
        {
            if (Inschrijvingen.Count() <=MaximumAantalPlaatsen)
            {
                Inschrijving inschr = new Inschrijving(gebruiker, this);
                Inschrijvingen.Add(inschr);
            }
            else {
                throw new Exception("Sessie is volzet");
            }
        }

        public void RemoveInschrijving(Gebruiker gebruiker)
        {
            Inschrijving i = Inschrijvingen.FirstOrDefault(e => e.Gebruiker == gebruiker);
            Inschrijvingen.Remove(i);
        }

        public void AddFeedback(Feedback feedback)
        {
            
            Feedback.Add(feedback);
        }

        public void RemoveFeedback(Gebruiker gebruiker)
        {
            Inschrijving i = Inschrijvingen.FirstOrDefault(e => e.Gebruiker == gebruiker);
            Inschrijvingen.Remove(i);
        }

        public void AddAankondiging(Gebruiker gebruiker, DateTime publicatieDatum, string inhoud, bool automatischeHerinnering, int? dagenVooraf)
        {
            Aankondiging aank = new Aankondiging(this, gebruiker, publicatieDatum, inhoud, automatischeHerinnering, dagenVooraf);
            Aankondigingen.Add(aank);
        }

        public void RemoveAankondiging(Gebruiker gebruiker)
        {
            Inschrijving i = Inschrijvingen.FirstOrDefault(e => e.Gebruiker == gebruiker);
            Inschrijvingen.Remove(i);
        }
        #endregion
    }
}

