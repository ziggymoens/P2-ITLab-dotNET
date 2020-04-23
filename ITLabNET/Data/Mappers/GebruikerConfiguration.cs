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

            builder.HasOne(t => t.Profielfoto).WithOne().OnDelete(DeleteBehavior.Restrict).HasForeignKey<Media>(t => t.MediaId);
           /* builder.HasOne(t => t.CurrentProfiel).WithOne();
            builder.HasOne(t => t.CurrentStatus).WithOne();*/
        }
    }
}
