using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.SessieViewModels
{
    public class AanwezigheidViewModel
    {
        [Required]
        [Display(Name = "Scan barcode studentenkaart of vul handmatig in")]
        public Gebruiker gebruiker { get; set; }
        public AanwezigheidViewModel() { }
        public AanwezigheidViewModel(Sessie sessie) : this() { }
    }
}
