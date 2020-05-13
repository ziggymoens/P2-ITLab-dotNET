﻿using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Models.SessieViewModels
{
    public class AanwezigheidViewModelBarcode
    {
        [Required]
        [Display(Name = "Scan barcode studentenkaart of vul handmatig in")]
        public long Barcode { get; set; }

        public Sessie Sessie { get; set; }
        public AanwezigheidViewModelBarcode() { }

        public AanwezigheidViewModelBarcode(Sessie sessie) : this()
        {
            Sessie = sessie;
        }
    }
}
