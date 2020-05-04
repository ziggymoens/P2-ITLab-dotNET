using ITLabNET.Models.Domain.Sessies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Data.Mappers
{
    internal class SessieConfiguration : IEntityTypeConfiguration<Sessie>
    {
        public void Configure(EntityTypeBuilder<Sessie> builder)
        {
            builder.ToTable("sessie");
            builder.HasKey(t => t.SessieId);
            builder.Property(s => s.CurrentState).HasConversion<string>();
            //builder.Property(t => t.SessieId).ValueGeneratedOnAdd();
        }
    }
}
