using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain.Gebruikers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITLabNET.Data.Mappers
{
    public class GebruikersStatusConfiguration : IEntityTypeConfiguration<GebruikerStatusState>
    {
        public void Configure(EntityTypeBuilder<GebruikerStatusState> builder)
        {
            builder.ToTable("gebruikersstatus");
            builder.HasKey(t => t.StatusId);

            //builder.HasOne(gs => gs.Gebruiker).WithOne();
            builder.HasDiscriminator<string>("GebruikerSatusState")
                .HasValue<ActiefStatusState>("Actief")
                .HasValue<GeblokkeerdStatusState>("Geblokkeerd")
                .HasValue<NietActiefStatusState>("NietActief");
        }
    }
}
