using ITLabNET.Models.Domain.Gebruikers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain
{
    public class Feedback
    {
        #region Fields
        private string _feedbackId;
        private Sessie _sessie;
        private Gebruiker _gebruiker;
        private string _tekst;
        private DateTime _date;
        private bool _verwijderd = false;
        #endregion
    }
}
