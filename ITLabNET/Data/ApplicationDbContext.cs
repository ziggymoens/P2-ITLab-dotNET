using System;
using System.Collections.Generic;
using System.Text;
using ITLabNET.Data.Mappers;
using ITLabNET.Models.Domain;
using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITLabNET.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Aankondiging> Aankondigingen { get; set; }
        public DbSet<Academiejaar> Academiejaren { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }       
        public DbSet<Herinnering> Herinneringen { get; set; }
        public DbSet<Inschrijving> Inschrijvingen { get; set; }
        public DbSet<Lokaal> Lokalen { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Sessie> Sessies { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AankondigingConfiguration());
            modelBuilder.ApplyConfiguration(new AcademiejaarConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new GebruikerConfiguration());            
            modelBuilder.ApplyConfiguration(new HerinneringConfiguration());
            modelBuilder.ApplyConfiguration(new InschrijvingConfiguration());
            modelBuilder.ApplyConfiguration(new LokaalConfiguration());
            modelBuilder.ApplyConfiguration(new MediaConfiguration());
            modelBuilder.ApplyConfiguration(new SessieConfiguration());
        }
    }
}
