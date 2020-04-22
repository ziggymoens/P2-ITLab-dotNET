﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ITLabNET.Data.Mappers
{
    public class AankondigingConfiguration : IEntityTypeConfiguration<Aankondiging>
    {
        public void Configure(EntityTypeBuilder<Aankondiging> builder)
        {
            builder.ToTable("aankondiging");
            builder.HasKey(t => t.AankondigingsId);
        }
    }
}
