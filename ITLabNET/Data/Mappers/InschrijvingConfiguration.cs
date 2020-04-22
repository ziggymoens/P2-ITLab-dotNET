using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITLabNET.Data.Mappers
{
    public class InschrijvingConfiguration : IEntityTypeConfiguration<Inschrijving>
    {
        public void Configure(EntityTypeBuilder<Inschrijving> builder)
        {
            throw new NotImplementedException();
        }
    }
}
