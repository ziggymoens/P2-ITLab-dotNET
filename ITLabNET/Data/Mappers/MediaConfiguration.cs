using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain;
using ITLabNET.Models.Domain.Sessies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITLabNET.Data.Mappers
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
           
        }
    }
}
