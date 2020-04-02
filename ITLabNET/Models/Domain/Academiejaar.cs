using System;
using System.Collections.Generic;
using ITLabNET.Models.Domain.Sessies;

namespace ITLabNET.Models.Domain
{
    public class Academiejaar
    {
        #region Fields
        private int _academiejaar;
        private ICollection<Sessie> _sessies;
        private DateTime _start;
        private DateTime _eind;
        private string _academiejaarString;
        private string _startString;
        private string _eindString;
        private int _aantal;
        #endregion
    }
}