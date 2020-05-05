using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain;
using ITLabNET.Models.Domain.Gebruikers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITLabNET.Data.Mappers
{
    public class GebruikerConfiguration : IEntityTypeConfiguration<Gebruiker>
    {
        public void Configure(EntityTypeBuilder<Gebruiker> builder)
        {
            builder.ToTable("gebruiker");
            builder.HasKey(t => t.Gebruikersnaam);

            builder.Property(t => t.CurrentProfiel).HasConversion<string>();
            builder.Property(t => t.CurrentStatus).HasConversion<string>();
            builder.HasOne(t => t.Profielfoto).WithOne().OnDelete(DeleteBehavior.Restrict).HasForeignKey<Media>(t => t.MediaId);           
        }
    }
}
