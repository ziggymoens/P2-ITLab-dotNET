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
    }
}
