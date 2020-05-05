using ITLabNET.Models.Domain.Sessies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.SessieViewModels
{
    public class FeedbackViewModel
    {
        [Required, MaxLength(500)]
        [Display(Name = ("Vul hier uw feedback in."))]
        public string Tekst { get; set; }
        public FeedbackViewModel() {}
        public FeedbackViewModel(Sessie sessie) : this() { }

    }
}
