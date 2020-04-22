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
            builder.Property(t => t.Gebruikersnaam).IsRequired();
            builder.Property(t => t.Barcode).IsRequired();
            builder.Property(t => t.Wachtwoord).IsRequired();

            builder.HasOne(t => t.Profielfoto).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade).HasForeignKey<Media>(t => t.MediaId);           
        }
    }
}
