using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain.Gebruikers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITLabNET.Data.Mappers
{
    public class GebruikersStatusConfiguration : IEntityTypeConfiguration<GebruikerProfielState>
    {
        public void Configure(EntityTypeBuilder<GebruikerProfielState> builder)
        {
            throw new NotImplementedException();
        }
    }
}
