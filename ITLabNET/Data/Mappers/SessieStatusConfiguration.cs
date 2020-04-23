﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain.Sessies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITLabNET.Data.Mappers
{
    internal class SessieStatusConfiguration : IEntityTypeConfiguration<SessieState>
    {
        public void Configure(EntityTypeBuilder<SessieState> builder)
        {
            builder.ToTable("sessiestatus");
            builder.HasKey(t => t.StatusId);

            // builder.HasOne(ss => ss.Sessie).WithOne(s => s.CurrentState).IsRequired().HasForeignKey<Sessie>(t => t.sessieId);
            builder.HasDiscriminator<string>("SessieState").HasValue<GeslotenState>("Gesloten").HasValue<OpenState>("Open").HasValue<NietZichtbaarState>("NietZichtbaar").HasValue<ZichtbaarState>("Zichtbaar");
        }
    }
}
