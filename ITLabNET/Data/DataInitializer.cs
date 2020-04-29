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
            //_dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                #region Gebruikers
                Gebruiker Jonathan = new Gebruiker("Jonathan Vanden Eynden", "jonathan.vandeneyndenvanlysebeth@student.hogent.be", 1133294124035L, "hoofdverantwoordelijke", "actief", "P@ssword1");
                Gebruiker Ziggy = new Gebruiker("Ziggy Moens", "ziggy.moens@student.hogent.be", 1117212595596L, "verantwoordelijke", "actief", "P@ssword1");
                Gebruiker Kilian = new Gebruiker("Kilian Hoefman", "kilian.hoefman@student.hogent.be", 1141420613636L, "gebruiker", "actief", "P@ssword1");

                var gebruikers = new List<Gebruiker> { Jonathan, Ziggy, Kilian };
                var profielen = new List<GebruikerProfielState> { Jonathan.CurrentProfiel, Ziggy.CurrentProfiel, Kilian.CurrentProfiel };
                var statussen = new List<GebruikerStatusState> { Jonathan.CurrentStatus, Ziggy.CurrentStatus, Kilian.CurrentStatus };
                _dbContext.Gebruikers.AddRange(gebruikers);
                _dbContext.GebruikersProfielen.AddRange(profielen);
                _dbContext.GebruikersStatussen.AddRange(statussen);
                await CreateUser(Jonathan.Gebruikersnaam, "jonathan.vandeneyndenvanlysebeth@student.hogent.be", Jonathan.Wachtwoord, "Hoofdverantwoordelijke");
                await CreateUser(Ziggy.Gebruikersnaam, "ziggy.moens@student.hogent.be", Ziggy.Wachtwoord, "Verantwoordelijke");
                await CreateUser(Kilian.Gebruikersnaam, "kilian.hoefman@student.hogent.be", Kilian.Wachtwoord, "Gebruiker");
                #endregion

                #region Lokalen
                Lokaal lokaal1 = new Lokaal("GSCHB1.014", "LESLOKAAL", 50);
                Lokaal lokaal2 = new Lokaal("GSCHB0.064", "AUDITORIUM", 104);
                Lokaal lokaal3 = new Lokaal("GSCHB1.015", "AUDITORIUM", 101);
                Lokaal lokaal4 = new Lokaal("GSCHB1.017", "AUDITORIUM", 106);
                Lokaal lokaal5 = new Lokaal("GSCHB1.032", "AUDITORIUM", 153);
                Lokaal lokaal6 = new Lokaal("GSCHB1.034", "AUDITORIUM", 107);
                Lokaal lokaal7 = new Lokaal("GSCHB2.015", "AUDITORIUM", 101);
                Lokaal lokaal8 = new Lokaal("GSCHB2.018", "AUDITORIUM", 107);
                Lokaal lokaal9 = new Lokaal("GSCHB3.019", "AUDITORIUM", 102);
                Lokaal lokaal10 = new Lokaal("GSCHB1.012", "LESLOKAAL", 45);
                Lokaal lokaal11 = new Lokaal("GSCHB1.013", "LESLOKAAL", 50);
                Lokaal lokaal12 = new Lokaal("GSCHB2.005", "LESLOKAAL", 75);
                Lokaal lokaal13 = new Lokaal("GSCHB2.006", "LESLOKAAL", 35);
                Lokaal lokaal14 = new Lokaal("GSCHB2.007", "LESLOKAAL", 34);
                Lokaal lokaal15 = new Lokaal("GSCHB2.008", "LESLOKAAL", 41);
                Lokaal lokaal16 = new Lokaal("GSCHB2.012", "LESLOKAAL", 54);
                Lokaal lokaal17 = new Lokaal("GSCHB2.013", "LESLOKAAL", 54);
                Lokaal lokaal18 = new Lokaal("GSCHB2.014", "LESLOKAAL", 54);
                Lokaal lokaal19 = new Lokaal("GSCHB3.006", "LESLOKAAL", 34);
                Lokaal lokaal20 = new Lokaal("GSCHB3.007", "LESLOKAAL", 35);
                Lokaal lokaal21 = new Lokaal("GSCHB3.008", "LESLOKAAL", 34);
                Lokaal lokaal22 = new Lokaal("GSCHB3.011", "LESLOKAAL", 34);
                Lokaal lokaal23 = new Lokaal("GSCHB3.014", "LESLOKAAL", 45);
                Lokaal lokaal24 = new Lokaal("GSCHB3.015", "LESLOKAAL", 48);
                Lokaal lokaal25 = new Lokaal("GSCHB3.038", "LESLOKAAL", 34);
                Lokaal lokaal26 = new Lokaal("GSCHB3.039", "LESLOKAAL", 60);
                Lokaal lokaal27 = new Lokaal("GSCHB4.005", "LESLOKAAL", 56);
                Lokaal lokaal28 = new Lokaal("GSCHB4.006", "LESLOKAAL", 35);
                Lokaal lokaal29 = new Lokaal("GSCHB4.008", "LESLOKAAL", 34);
                Lokaal lokaal30 = new Lokaal("GSCHB4.011", "LESLOKAAL", 35);
                Lokaal lokaal31 = new Lokaal("GSCHB4.014", "LESLOKAAL", 49);
                Lokaal lokaal32 = new Lokaal("GSCHB4.015", "LESLOKAAL", 49);
                Lokaal lokaal33 = new Lokaal("GSCHB4.016", "LESLOKAAL", 49);
                Lokaal lokaal34 = new Lokaal("GSCHB4.017", "LESLOKAAL", 49);
                Lokaal lokaal35 = new Lokaal("GSCHB4.039", "LESLOKAAL", 60);
                Lokaal lokaal36 = new Lokaal("GSCHB4.041", "LESLOKAAL", 60);
                Lokaal lokaal37 = new Lokaal("GSCHB4.042", "LESLOKAAL", 60);
                Lokaal lokaal38 = new Lokaal("GSCHB1.008", "PC_LOKAAL", 20);
                Lokaal lokaal39 = new Lokaal("GSCHB1.026", "PC_LOKAAL", 24);
                Lokaal lokaal40 = new Lokaal("GSCHB1.029", "PC_LOKAAL", 36);
                Lokaal lokaal41 = new Lokaal("GSCHB1.031", "PC_LOKAAL", 36);
                Lokaal lokaal42 = new Lokaal("GSCHB1.036", "PC_LOKAAL", 32);
                Lokaal lokaal43 = new Lokaal("GSCHB1.037", "PC_LOKAAL", 32);
                //Lokaal lokaal44 = new Lokaal("GSCHB1.032", "PC_LOKAAL", 64);
                Lokaal lokaal45 = new Lokaal("GSCHB4.012", "PC_LOKAAL", 35);
                Lokaal lokaal46 = new Lokaal("GSCHB4.013", "PC_LOKAAL", 42);
                Lokaal lokaal47 = new Lokaal("GSCHB4.036", "PC_LOKAAL", 60);
                Lokaal lokaal48 = new Lokaal("GSCHB1.011", "LAPTOPLOKAAL", 24);
                Lokaal lokaal49 = new Lokaal("GSCHB2.009", "LAPTOPLOKAAL", 28);
                Lokaal lokaal50 = new Lokaal("GSCHB2.010", "LAPTOPLOKAAL", 28);
                Lokaal lokaal51 = new Lokaal("GSCHB2.011", "LAPTOPLOKAAL", 28);
                Lokaal lokaal52 = new Lokaal("GSCHB3.012", "LAPTOPLOKAAL", 28);
                Lokaal lokaal53 = new Lokaal("GSCHB3.013", "LAPTOPLOKAAL", 38);
                Lokaal lokaal54 = new Lokaal("GSCHB3.026", "LAPTOPLOKAAL", 28);
                Lokaal lokaal55 = new Lokaal("GSCHB3.027", "LAPTOPLOKAAL", 28);
                Lokaal lokaal56 = new Lokaal("GSCHB3.028", "LAPTOPLOKAAL", 26);
                Lokaal lokaal57 = new Lokaal("GSCHB3.029", "LAPTOPLOKAAL", 36);
                Lokaal lokaal58 = new Lokaal("GSCHB3.035", "LAPTOPLOKAAL", 28);
                Lokaal lokaal59 = new Lokaal("GSCHB3.036", "LAPTOPLOKAAL", 70);
                Lokaal lokaal60 = new Lokaal("GSCHB3.037", "LAPTOPLOKAAL", 38);
                Lokaal lokaal61 = new Lokaal("GSCHB4.029", "LAPTOPLOKAAL", 25);
                Lokaal lokaal62 = new Lokaal("GSCHB4.026", "IT_LAB", 30);
                Lokaal lokaal63 = new Lokaal("GSCHC0.125", "AUDITORIUM", 288);
                Lokaal lokaal64 = new Lokaal("GSCHC0.155", "AUDITORIUM", 245);
                Lokaal lokaal65 = new Lokaal("GSCHC1.005", "AUDITORIUM", 105);
                Lokaal lokaal66 = new Lokaal("GSCHC1.155", "AUDITORIUM", 393);
                Lokaal lokaal67 = new Lokaal("GSCHC3.010", "AUDITORIUM", 106);
                Lokaal lokaal68 = new Lokaal("GSCHC4.105", "AUDITORIUM", 106);
                Lokaal lokaal69 = new Lokaal("GSCHC4.130", "AUDITORIUM", 113);
                Lokaal lokaal70 = new Lokaal("GSCHC4.135", "AUDITORIUM", 170);
                Lokaal lokaal71 = new Lokaal("GSCHC0.006", "LESLOKAAL", 25);
                Lokaal lokaal72 = new Lokaal("GSCHC0.007", "LESLOKAAL", 25);
                Lokaal lokaal73 = new Lokaal("GSCHC1.003", "LESLOKAAL", 24);
                Lokaal lokaal74 = new Lokaal("GSCHC1.004", "LESLOKAAL", 24);
                Lokaal lokaal75 = new Lokaal("GSCHC1.007", "LESLOKAAL", 29);
                Lokaal lokaal76 = new Lokaal("GSCHC1.008", "LESLOKAAL", 46);
                Lokaal lokaal77 = new Lokaal("GSCHC1.009", "LESLOKAAL", 46);
                Lokaal lokaal78 = new Lokaal("GSCHC1.010", "LESLOKAAL", 46);
                Lokaal lokaal79 = new Lokaal("GSCHC1.011", "LESLOKAAL", 46);
                Lokaal lokaal80 = new Lokaal("GSCHC1.012", "LESLOKAAL", 68);
                Lokaal lokaal81 = new Lokaal("GSCHC2.010", "LESLOKAAL", 66);
                Lokaal lokaal82 = new Lokaal("GSCHC2.012", "LESLOKAAL", 65);
                Lokaal lokaal83 = new Lokaal("GSCHC2.014", "LESLOKAAL", 64);
                Lokaal lokaal84 = new Lokaal("GSCHC2.016", "LESLOKAAL", 62);
                Lokaal lokaal85 = new Lokaal("GSCHC3.006", "LESLOKAAL", 56);
                Lokaal lokaal86 = new Lokaal("GSCHC3.008", "LESLOKAAL", 47);
                Lokaal lokaal87 = new Lokaal("GSCHC3.012", "LESLOKAAL", 30);
                Lokaal lokaal88 = new Lokaal("GSCHC3.013", "LESLOKAAL", 30);
                Lokaal lokaal89 = new Lokaal("GSCHC4.140", "LESLOKAAL", 30);
                Lokaal lokaal90 = new Lokaal("GSCHC1.160", "PC_LOKAAL", 15);
                Lokaal lokaal91 = new Lokaal("GSCHC2.003", "PC_LOKAAL", 40);
                Lokaal lokaal92 = new Lokaal("GSCHC1.045", "TAALLAB", 30);
                Lokaal lokaal93 = new Lokaal("GSCHC0.008", "LAPTOPLOKAAL", 93);
                Lokaal lokaal94 = new Lokaal("GSCHD1.028", "AUDITORIUM", 334);
                Lokaal lokaal95 = new Lokaal("GSCHP1.054", "AUDITORIUM", 288);
                Lokaal lokaal96 = new Lokaal("GSCHP1.212", "AUDITORIUM", 90);
                Lokaal lokaal97 = new Lokaal("GSCHP1.213", "AUDITORIUM", 90);
                Lokaal lokaal98 = new Lokaal("GSCHP1.214", "AUDITORIUM", 90);
                Lokaal lokaal99 = new Lokaal("GSCHP1.105", "LESLOKAAL", 53);
                Lokaal lokaal100 = new Lokaal("GSCHP1.215", "LESLOKAAL", 35);
                Lokaal lokaal101 = new Lokaal("GSCHP0.056", "PC_LOKAAL", 30);
                Lokaal lokaal102 = new Lokaal("GSCHP1.221", "PC_LOKAAL", 20);
                Lokaal lokaal103 = new Lokaal("GSCHP0.061", "LAPTOPLOKAAL", 21);
                Lokaal lokaal104 = new Lokaal("GSCHP0.115", "LAPTOPLOKAAL", 106);
                Lokaal lokaal105 = new Lokaal("GSCHP1.052", "LAPTOPLOKAAL", 30);
                Lokaal lokaal106 = new Lokaal("GSCHP1.055", "LAPTOPLOKAAL", 30);
                Lokaal lokaal107 = new Lokaal("GSCHP1.056", "LAPTOPLOKAAL", 30);
                Lokaal lokaal108 = new Lokaal("GSCHP1.057", "LAPTOPLOKAAL", 30);
                Lokaal lokaal109 = new Lokaal("GSCHP1.217", "LAPTOPLOKAAL", 30);
                Lokaal lokaal110 = new Lokaal("GSCHP1.218", "LAPTOPLOKAAL", 70);
                Lokaal lokaal111 = new Lokaal("GSCHP1.255", "LAPTOPLOKAAL", 18);
                Lokaal lokaal112 = new Lokaal("GAARB0.020", "AUDITORIUM", 142);
                Lokaal lokaal113 = new Lokaal("GAARB2.002", "AUDITORIUM", 106);
                Lokaal lokaal114 = new Lokaal("GAARB0.027", "LESLOKAAL", 35);
                Lokaal lokaal115 = new Lokaal("GAARB0.028", "LESLOKAAL", 35);
                Lokaal lokaal116 = new Lokaal("GAARB0.029", "LESLOKAAL", 35);
                Lokaal lokaal117 = new Lokaal("GAARB0.030", "LESLOKAAL", 35);
                Lokaal lokaal118 = new Lokaal("GAARB0.031", "LESLOKAAL", 35);
                Lokaal lokaal119 = new Lokaal("GAARB0.032", "LESLOKAAL", 35);
                Lokaal lokaal120 = new Lokaal("GAARB0.033", "VERGADERZAAL",15);
                Lokaal lokaal121 = new Lokaal("GAARB1.007", "LESLOKAAL", 33);
                Lokaal lokaal122 = new Lokaal("GAARB1.008", "LESLOKAAL", 33);
                Lokaal lokaal123 = new Lokaal("GAARB1.009", "LESLOKAAL", 33);
                Lokaal lokaal124 = new Lokaal("GAARB1.013", "LESLOKAAL",33);
                /*Lokaal lokaal125 = new Lokaal("GAARB1.014", "LESLOKAAL", 33);*/
                Lokaal lokaal126 = new Lokaal("GAARB1.015", "LESLOKAAL", 33);
                Lokaal lokaal127 = new Lokaal("GAARB0.047", "PC_LOKAAL", 30);
                Lokaal lokaal128 = new Lokaal("GAARB1.023","PC_LOKAAL",30);

                var lokalen = new List<Lokaal> { lokaal1, lokaal2, lokaal3, lokaal4, lokaal5, lokaal6, lokaal7, lokaal8, lokaal9, lokaal10,
                    lokaal11, lokaal12, lokaal13, lokaal14, lokaal15, lokaal16, lokaal17, lokaal18, lokaal19, lokaal20,
                    lokaal21, lokaal22, lokaal23, lokaal24, lokaal25, lokaal26, lokaal27, lokaal28, lokaal29, lokaal30,
                    lokaal31, lokaal32, lokaal33, lokaal34, lokaal35, lokaal36, lokaal37, lokaal38, lokaal39, lokaal40,
                    lokaal41, lokaal42, lokaal43, /*lokaal44,*/ lokaal45, lokaal46, lokaal47, lokaal48, lokaal49, lokaal50,
                    lokaal51, lokaal52, lokaal53, lokaal54, lokaal55, lokaal56, lokaal57, lokaal58, lokaal59, lokaal60,
                    lokaal61, lokaal62, lokaal63, lokaal64, lokaal65, lokaal66, lokaal67, lokaal68, lokaal69, lokaal70,
                    lokaal71, lokaal72, lokaal73, lokaal74, lokaal75, lokaal76, lokaal77, lokaal78, lokaal79, lokaal80,
                    lokaal81, lokaal82, lokaal83, lokaal84, lokaal85, lokaal86, lokaal87, lokaal88, lokaal89, lokaal90,
                    lokaal91, lokaal92, lokaal93, lokaal94, lokaal95, lokaal96, lokaal97, lokaal98, lokaal99, lokaal100,
                    lokaal101, lokaal102, lokaal103, lokaal104, lokaal105, lokaal106, lokaal107, lokaal108, lokaal109, lokaal110,
                    lokaal111, lokaal112, lokaal113, lokaal114, lokaal115, lokaal116, lokaal117, lokaal118, lokaal119, lokaal120,
                    lokaal121, lokaal122, lokaal123, lokaal124, /*lokaal125,*/ lokaal126, lokaal127, lokaal128
                };
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
                Sessie sessie3 = new Sessie("Inleiding tot Github", "Een korte en krachtige inleiding tot github. Alles wat men hoef te weten over de werking en de structuur", DateTime.Now.AddDays(4).AddHours(20), DateTime.Now.AddDays(4).AddHours(21).AddMinutes(30), lokaal4, Ziggy, academiejaar2021, "gesloten");
                Sessie sessie4 = new Sessie("Infosessie internationlisering IT", "Infosessie over de mogelijkheden tot buitenlandse studie of stage", DateTime.Now.AddDays(7), DateTime.Now.AddDays(7).AddHours(3), lokaal8, Jonathan, academiejaar2021, "gesloten");
                Sessie sessie5 = new Sessie("The power of unix", "Korte sessie over de kracht van de command prompt in unix besturingssystemen", DateTime.Now.AddDays(6), DateTime.Now.AddDays(6).AddHours(1).AddMinutes(15), lokaal62, Jonathan, academiejaar2021, "zichtbaar");
                Sessie sessie6 = new Sessie("What the future holds for AI", "Korte keynote van Elon Musk over zijn visie van wat er met AI te gebeuren staat", DateTime.Now.AddDays(2), DateTime.Now.AddDays(2).AddHours(2).AddMinutes(15), lokaal62, Ziggy, academiejaar2021, "zichtbaar");
                var sessies = new List<Sessie> { sessie1, sessie2, sessie3, sessie4, sessie5, sessie6 };
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
