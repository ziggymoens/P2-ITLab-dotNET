using ITLabNET.Models.Domain;
using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ITLabNET.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public DataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                #region Gebruikers
                Gebruiker Jonathan = new Gebruiker("Jonathan Vanden Eynden", "jonathan.vandeneyndenvanlysebeth@student.hogent.be", 1133294124035L, "hoofdverantwoordelijke", "actief", "P@ssword1");
                Gebruiker Ziggy = new Gebruiker("Ziggy Moens", "ziggy.moens@student.hogent.be", 1117212595596, "verantwoordelijke", "actief", "P@ssword1");
                
                var gebruikers = new List<Gebruiker> { Jonathan, Ziggy };
                var profielen = new List<GebruikerProfielState> { Jonathan.CurrentProfiel, Ziggy.CurrentProfiel };
                var statussen = new List<GebruikerStatusState> { Jonathan.CurrentStatus, Ziggy.CurrentStatus };
                _dbContext.Gebruikers.AddRange(gebruikers);
                _dbContext.GebruikersProfielen.AddRange(profielen);
                _dbContext.GebruikersStatussen.AddRange(statussen);
                await CreateUser(Jonathan.Gebruikersnaam, "jonathan.vandeneyndenvanlysebeth@student.hogent.be", Jonathan.Wachtwoord, "Hoofdverantwoordelijke");
                await CreateUser(Ziggy.Gebruikersnaam, "ziggy.moens@student.hogent.be", Ziggy.Wachtwoord, "Verantwoordelijke");
                #endregion

                #region Lokalen
                Lokaal lokaal1 = new Lokaal("GSCHB1.014", "LESLOKAAL", 50);
                Lokaal lokaal2 = new Lokaal("GSCHB0.064", "AUDITORIUM", 104);
                var lokalen = new List<Lokaal> { lokaal1, lokaal2 };
                _dbContext.Lokalen.AddRange(lokalen);
                #endregion

                #region Academiejaren
                Academiejaar academiejaar2021 = new Academiejaar(2021, new DateTime(2021, 1, 1), new DateTime(2021, 1, 1).AddYears(1).AddDays(-1));
                Academiejaar academiejaar2022 = new Academiejaar(2022, new DateTime(2022, 1, 1), new DateTime(2022, 1, 1).AddYears(1).AddDays(-1));
                var academiejaren = new List<Academiejaar> { academiejaar2021, academiejaar2022 };
                _dbContext.Academiejaren.AddRange(academiejaren);
                #endregion

                #region Sessies
                Sessie sessie1 = new Sessie("Inleiding tot Trello", "beschrijving", DateTime.Now.AddDays(2), DateTime.Now.AddDays(2).AddHours(2), lokaal1, Jonathan, academiejaar2021, "gesloten");
                Sessie sessie2 = new Sessie("Inleiding tot UNIX", "beschrijving", DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddHours(3), lokaal2, Jonathan, academiejaar2021, "gesloten");
                var sessies = new List<Sessie> { sessie1, sessie2 };
                _dbContext.Sessies.AddRange(sessies);
                #endregion

                _dbContext.SaveChanges();
            }
        }

        private async Task CreateUser(string username, string email, string password, string role)
        {
            var user = new IdentityUser { UserName = username, Email = email };
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
        }

        
    }
}
