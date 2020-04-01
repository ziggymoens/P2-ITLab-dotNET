using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain
{
    public class Inschrijving
    {
        #region Fields
        private string _inschrijvingsId;
        private Gebruiker _gebruiker;
        private Sessie _sessie;
        private DateTime _inschrijvingsdatum;
        private bool _statusAanwezigheid = false;
        private bool _verwijderd;
        #endregion
    }
}
