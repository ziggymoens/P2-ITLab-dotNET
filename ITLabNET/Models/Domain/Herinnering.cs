using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.Domain
{
    public class Herinnering
    {
        #region Fields
        private string _herinneringsId;
        private string _dagenVooraf;
        private bool _verwijderd = false;
        #endregion

        #region Properties
        public string HerinneringsId
        {
            get { return _herinneringsId; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("HerrinneringsId mag niet null of leeg zijn");
                _herinneringsId = value;
            }
        }

        public string DagenVooraf
        {
            get { return _dagenVooraf; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("DagenVooraf mag niet null of leeg zijn");
                _dagenVooraf = value;
            }
        }

        public bool Verwijderd
        {
            get { return _verwijderd; }
            set { _verwijderd = value; }
        }
        #endregion

    }
}
