using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain.Sessies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITLabNET.Data.Mappers
{
    internal class SessieStatusConfiguration : IEntityTypeConfiguration<SessieState>
    {
        public void Configure(EntityTypeBuilder<SessieState> builder)
        {
            throw new NotImplementedException();
        }
    }
}
