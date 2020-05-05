using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain.Gebruikers
{
    public class Gebruiker
    {
        #region Fields
        private string _gebruikersnaam;
        private long _barcode;
        private string _naam;
        private string _wachtwoord;
        private bool _verwijderd = false;
        private Media _profielfoto;
        private GebruikerStatusStates _currentStatus;
        private GebruikerProfielStates _currentProfiel;
        private int _inlogPogingen;
        private DateTime? _laatstIngelogd;
        #endregion

        #region Properties
        public string Gebruikersnaam
        {
            get => _gebruikersnaam;
            set
            {
                if (value == null || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Gebruikersnaam mag niet leeg of null zijn");
                _gebruikersnaam = value;
            }
        }

        public long Barcode
        {
            get => _barcode;
            set
            {                
                _barcode = value;
            }
        }

        public string Naam
        {
            get => _naam;
            set
            {                
                if (value == null || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Naam mag niet leeg of null zijn");
                _naam = value;
            }
        }

        public string Wachtwoord
        {
            get => _wachtwoord;
            set
            {
                _wachtwoord = value;
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

        public Media Profielfoto
        {
            get => _profielfoto;
            set
            {
                if (value == null)
                    throw new ArgumentException("ProfielFoto mag niet leeg of null zijn");
                _profielfoto = value;
            }
        }

        public GebruikerProfielStates CurrentProfiel { get => _currentProfiel; }

        public void setCurrentProfiel (string gebruikersprofiel)
        {
            if (gebruikersprofiel == null || string.IsNullOrEmpty(gebruikersprofiel) )
            {
                throw new ArgumentException("Gebruikersprofiel mag niet leeg of null zijn");
            }            
            switch (gebruikersprofiel)
            {
                case "hoofdverantwoordelijke":
                    toProfielState(GebruikerProfielStates.Hoofdverantwoordelijke);
                    break;
                case "verantwoordelijke":
                    toProfielState(GebruikerProfielStates.Verantwoordelijke);
                    break;
                case "gebruiker":
                    toProfielState(GebruikerProfielStates.Gebruiker);
                    break;
                default:
                    throw new ArgumentException("Gebruikersprofiel onbekend " + gebruikersprofiel);
            }
        }

        public GebruikerStatusStates CurrentStatus { get => _currentStatus; }

        public void setCurrentStatus(string status)
        {
            if (status == null || string.IsNullOrEmpty(status))
            {
                throw new ArgumentException("Gebruikersprofiel is leeg of null");
            }            
            switch (status)
            {
                case "actief":
                    toStatusState(GebruikerStatusStates.Actief);
                    break;
                case "geblokkeerd":
                    toStatusState(GebruikerStatusStates.Geblokkeerd);
                    break;
                case "niet actief":
                    toStatusState(GebruikerStatusStates.NietActief);
                    break;
                default:
                    throw new ArgumentException("Gebruikerstatus onbekend " + status);
            }
        }

        public int InlogPogingen
        {
            get => _inlogPogingen;
            private set
            {
                _inlogPogingen = value;
            }
        }

        public DateTime? LaatstIngelogd
        {
            get => _laatstIngelogd;
            set
            {
                _laatstIngelogd = value;
            }
        }
        #endregion

        #region Constructor
        public Gebruiker()
        {

        }
        public Gebruiker(string naam, string gebruikersnaam, long barcode, string gebruikersprofiel, string gebruikersstatus,  string wachtwoord)
        {
            Naam = naam;
            Gebruikersnaam = gebruikersnaam;
            Barcode = barcode;
            setCurrentProfiel(gebruikersprofiel);
            setCurrentStatus(gebruikersstatus);
            InlogPogingen = 0;
            Wachtwoord = wachtwoord;
        }
        #endregion

        #region Methods
        public void toProfielState(GebruikerProfielStates profielState) { _currentProfiel = profielState; }

        public void toStatusState(GebruikerStatusStates statusState) { _currentStatus = statusState; }
        #endregion
    }


}
