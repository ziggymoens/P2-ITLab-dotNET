using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain
{
    public class Media
    {
        #region Fields
        private string _mediaId;
        private Sessie _sessie;
        private Gebruiker _gebruiker;
        private string _url;
        private string _type;
        private bool _verwijderd = false;
        private byte[] _afbeelding;
        #endregion

        #region Properties
        public string MediaId
        {
            get { return _mediaId; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("MediaId mag niet null of leeg zijn");
                _mediaId = value;
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

        public string Url
        {
            get { return _url; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Url mag niet null of leeg zijn");
                _url = value;
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

        public bool Verwijderd
        {
            get { return _verwijderd}
            set { _verwijderd = value; }
        }

        public byte[] Afbeelding
        {
            get { return _afbeelding; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Afbeelding mag niet null zijn");
            }
        }
        #endregion
    }
}
