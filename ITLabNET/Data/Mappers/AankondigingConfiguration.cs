using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain;
using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
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
            builder.Property(t => t.Inhoud).HasMaxLength(1000);
        }
    }
}
