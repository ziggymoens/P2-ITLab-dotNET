using ITLabNET.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLabNET.Data.Mappers
{
    public class GebouwConfiguration : IEntityTypeConfiguration<Gebouw>
    {
        public void Configure(EntityTypeBuilder<Gebouw> builder)
        {
            builder.ToTable("Gebouw");
            builder.HasKey(g => g.GebouwId);
        }
    }
}
