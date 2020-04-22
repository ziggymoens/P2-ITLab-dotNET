using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITLabNET.Data.Mappers
{
    public class AcademiejaarConfiguration : IEntityTypeConfiguration<Academiejaar>
    {
        public void Configure(EntityTypeBuilder<Academiejaar> builder)
        {
            builder.ToTable("academiejaar");
            builder.HasKey(t => t.AcademieJaar);
        }
    }
}
