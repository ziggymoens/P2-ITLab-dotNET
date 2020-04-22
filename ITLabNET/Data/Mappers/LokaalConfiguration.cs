using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITLabNET.Data.Mappers
{
    public class LokaalConfiguration : IEntityTypeConfiguration<Lokaal>
    {
        public void Configure(EntityTypeBuilder<Lokaal> builder)
        {
            builder.ToTable("lokaal");
        }
    }
}
