﻿using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain
{
    public class Feedback
    {
        #region Fields
        private int _feedbackId;
        private Sessie _sessie;
        private Gebruiker _gebruiker;
        private string _tekst;
        private DateTime? _date;
        private bool _verwijderd = false;
        #endregion

        #region Properties
        public int FeedbackId
        {
            get{ return _feedbackId; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("FeedbackId mag niet kleiner of gelijk aan 0 zijn");
                _feedbackId = value;
            }
        }

        public Sessie Sessie
        {
            get{ return _sessie; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Sessie mag niet null zijn");
                _sessie = value;
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

        public string Tekst
        {
            get { return _tekst; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Tekst mag niet leeg of null zijn");
                _tekst = value;
            }
        }

        public DateTime? Date
        {
            get { return _date; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Date mag niet null zijn");
                _date = value;
            }
        }

        public bool Verwijderd
        {
            get { return _verwijderd; }
            set { _verwijderd = value; }
        }
        #endregion

        #region constructors
        public Feedback() { }
        public Feedback(Sessie sessie, Gebruiker gebruiker, string tekst, DateTime date)
        {
            Sessie = sessie;
            Gebruiker = gebruiker;
            Tekst = tekst;
            Date = date;
        }
        #endregion
    }
}
