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
        private bool _verwijderd;
        private Media _profielfoto;
        private GebruikerProfielState _currentProfiel;
        private GebruikerStatusState _currentStatus;
        private int _inlogPogingen;
        private DateTime _laatstIngelogd;
        #endregion
    }
}
