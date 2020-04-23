using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;

namespace ITLabNET.Models.Domain
{
    public class Aankondiging
    {
        #region Fields
        private string _aankondigingsId;
        private Herinnering _herinnering;
        private Gebruiker _gebruiker;
        private Sessie _sessie;
        private DateTime? _publicatiedatum;
        private string _inhoud;
        private bool _automatischeHerinnering;
        private bool _verwijderd = false;
        private int? _dagenVooraf;
        #endregion

        #region Properties
        public string AankondigingsId
        {
            get => _aankondigingsId;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Aankondigingsid mag niet null zijn");
                _aankondigingsId = value;
            }
        }

        public Herinnering Herinnering
        {
            get
            {
                return _herinnering;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("Herinnering mag niet null zijn");
                _herinnering = value;
            }
        }

        public Gebruiker Gebruiker
        {
            get
            {
                return _gebruiker;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("Gebruiker mag niet null zijn");
                _gebruiker = value;
            }
        }

        public Sessie Sessie
        {
            get
            {
                return _sessie;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("Sessie mag niet null zijn");
                _sessie = value;
            }
        }

        public DateTime? PublicatieDatum
        {
            get
            {
                return _publicatiedatum;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("Publicatiedatum mag niet null zijn");
                _publicatiedatum = value;
            }
        }

        public string Inhoud
        {
            get
            {
                return _inhoud;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Inhoud mag niet null of leeg zijn");
                _inhoud = value;
            }
        }

        public bool AutomatischeHerinnering
        {
            get { return _automatischeHerinnering; }
            set
            {
                _automatischeHerinnering = value;
            }
        }

        public bool Verwijderd
        {
            get { return _verwijderd; }
            set
            {
                _verwijderd = value;
            }
        }
        
        #endregion

        #region constructor
        public Aankondiging() { }

        //AANVULLEN
        public Aankondiging(Sessie sessie, Gebruiker gebruiker, DateTime publicatieDatum, string inhoud, bool automatischeHerinnering, int? dagenVooraf)
        {
            Sessie = sessie;
            Gebruiker = gebruiker;
            PublicatieDatum = publicatieDatum;
            Inhoud = inhoud;            
        }
        #endregion
    }
}
