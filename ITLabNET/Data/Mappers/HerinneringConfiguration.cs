using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITLabNET.Data.Mappers
{
    public class HerinneringConfiguration : IEntityTypeConfiguration<Herinnering>
    {
        public void Configure(EntityTypeBuilder<Herinnering> builder)
        {
            builder.ToTable("herinnering");
            builder.HasKey(t => t.HerinneringsId);
        }
    }
}
