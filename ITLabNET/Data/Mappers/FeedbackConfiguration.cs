﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITLabNET.Data.Mappers
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("feedback");
            builder.HasKey(t => t.FeedbackId);

            builder.Property(e => e.FeedbackId).ValueGeneratedOnAdd();
        }
    }
}
