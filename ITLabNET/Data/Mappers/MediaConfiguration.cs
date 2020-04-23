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
            /*builder.ToTable("media");
            builder.HasKey(t => t.MediaId);
            builder.HasOne(t => t.Sessie).WithMany(t => t.Media).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            builder.Property(t => t.Afbeelding).HasColumnName("afbeelding").HasMaxLength(int.MaxValue).IsRequired(true);
            builder.Property(t => t.Type).HasColumnName("type").IsRequired(true);
            builder.Property(t => t.Url).HasColumnName("url").IsRequired(true);
            builder.Property(t => t.Verwijderd).HasColumnName("verwijderd").IsRequired(false);
            builder.Property(t => t.Gebruiker).HasColumnName("gebruiker_gebruikersnaam").IsRequired(true);
            builder.Property(t => t.Sessie).HasColumnName("sessie_sessieId").IsRequired(true);*/
        }
    }
}
