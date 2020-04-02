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
        private DateTime _publicatiedatum;
        private string _inhoud;
        private bool _automatischeHerinnering;
        private bool _verwijderd = false;
        #endregion
    }
}
