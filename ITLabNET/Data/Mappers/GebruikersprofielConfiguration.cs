using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain.Gebruikers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITLabNET.Data.Mappers
{
    public class GebruikersprofielConfiguration : IEntityTypeConfiguration<GebruikerProfielState>
    {
        public void Configure(EntityTypeBuilder<GebruikerProfielState> builder)
        {
            builder.ToTable("gebruikersprofiel");
            builder.HasKey(t => t.ProfielId);

            /*builder.HasOne(gs => gs.Gebruiker).WithOne();*/

        }
    }
}
