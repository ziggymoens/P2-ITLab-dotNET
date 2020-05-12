﻿using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.SessieViewModels
{
    public class AanwezigheidViewModelGebruikersnaam
    {
        [Required]
        [Display(Name = "Voer gebruikersnaam in")]
        public string Gebruikersnaam { get; set; }
        public AanwezigheidViewModelGebruikersnaam() { }
        public AanwezigheidViewModelGebruikersnaam(Sessie sessie) : this() { }
    }
}
