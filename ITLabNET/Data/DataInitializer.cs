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
                Gebruiker Jonathan = new Gebruiker("Jonathan Vanden Eynden", "862361jv", 1133294124035L, "hoofdverantwoordelijke", "actief", "P@ssword1");
                Gebruiker Ziggy = new Gebruiker("Ziggy Moens", "123456zm", 1117212595596L, "verantwoordelijke", "actief", "P@ssword1");
                Gebruiker Kilian = new Gebruiker("Kilian Hoefman", "123456kh", 1141420613636L, "gebruiker", "actief", "P@ssword1");
                Gebruiker Seba = new Gebruiker("Sébastien De Pauw", "755223sd", 1136053896198L, "verantwoordelijke", "actief", "P@ssword1");
                Gebruiker Sven = new Gebruiker("Sven Wyseur", "123456sw", 1133340050431L, "gebruiker", "actief", "P@ssword1");

                var gebruikers = new List<Gebruiker> { Jonathan, Ziggy, Kilian, Sven, Seba };
                var profielen = new List<GebruikerProfielStates> { Jonathan.CurrentProfiel, Ziggy.CurrentProfiel, Kilian.CurrentProfiel, Sven.CurrentProfiel, Seba.CurrentProfiel };
                var statussen = new List<GebruikerStatusStates> { Jonathan.CurrentStatus, Ziggy.CurrentStatus, Kilian.CurrentStatus, Sven.CurrentStatus, Seba.CurrentStatus };
                _dbContext.Gebruikers.AddRange(gebruikers);
               /* _dbContext.GebruikersProfielen.AddRange(profielen);
                _dbContext.GebruikersStatussen.AddRange(statussen);*/
                await CreateUser(Jonathan.Gebruikersnaam, "jonathan.vandeneyndenvanlysebeth@student.hogent.be", Jonathan.Wachtwoord, "Hoofdverantwoordelijke");
                await CreateUser(Ziggy.Gebruikersnaam, "ziggy.moens@student.hogent.be", Ziggy.Wachtwoord, "Verantwoordelijke");
                await CreateUser(Kilian.Gebruikersnaam, "kilian.hoefman@student.hogent.be", Kilian.Wachtwoord, "Gebruiker");
                await CreateUser(Sven.Gebruikersnaam, "sven.wyseur@student.hogent.be", Sven.Wachtwoord, "Gebruiker");
                await CreateUser(Seba.Gebruikersnaam, "sebastien.depauw@student.hogent.be", Seba.Wachtwoord, "Verantwoordelijke");
                #endregion

                #region Lokalen
                Stad Gent = new Stad(9000, "Gent");
                Stad Aalst = new Stad(9300, "Aalst");

                Campus CampusSchoonmeersen = new Campus("Schoonmeersen");
                Campus CampusAalst = new Campus("Aalst");

                Gebouw SCHB = new Gebouw("Gebouw B");
                Gebouw SCHP = new Gebouw("Gebouw P");
                Gebouw SCHC = new Gebouw("Gebouw C");
                Gebouw SCHD = new Gebouw("Gebouw D");

                Gebouw AARB = new Gebouw("Gebouw B");

                Lokaal lokaal1 = new Lokaal("GSCHB1.014", "LESLOKAAL", 50, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal2 = new Lokaal("GSCHB0.064", "AUDITORIUM", 104, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal3 = new Lokaal("GSCHB1.015", "AUDITORIUM", 101, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal4 = new Lokaal("GSCHB1.017", "AUDITORIUM", 106, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal5 = new Lokaal("GSCHB1.032", "AUDITORIUM", 153, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal6 = new Lokaal("GSCHB1.034", "AUDITORIUM", 107, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal7 = new Lokaal("GSCHB2.015", "AUDITORIUM", 101, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal8 = new Lokaal("GSCHB2.018", "AUDITORIUM", 107, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal9 = new Lokaal("GSCHB3.019", "AUDITORIUM", 102, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal10 = new Lokaal("GSCHB1.012", "LESLOKAAL", 45, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal11 = new Lokaal("GSCHB1.013", "LESLOKAAL", 50, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal12 = new Lokaal("GSCHB2.005", "LESLOKAAL", 75, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal13 = new Lokaal("GSCHB2.006", "LESLOKAAL", 35, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal14 = new Lokaal("GSCHB2.007", "LESLOKAAL", 34, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal15 = new Lokaal("GSCHB2.008", "LESLOKAAL", 41, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal16 = new Lokaal("GSCHB2.012", "LESLOKAAL", 54, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal17 = new Lokaal("GSCHB2.013", "LESLOKAAL", 54, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal18 = new Lokaal("GSCHB2.014", "LESLOKAAL", 54, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal19 = new Lokaal("GSCHB3.006", "LESLOKAAL", 34, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal20 = new Lokaal("GSCHB3.007", "LESLOKAAL", 35, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal21 = new Lokaal("GSCHB3.008", "LESLOKAAL", 34, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal22 = new Lokaal("GSCHB3.011", "LESLOKAAL", 34, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal23 = new Lokaal("GSCHB3.014", "LESLOKAAL", 45, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal24 = new Lokaal("GSCHB3.015", "LESLOKAAL", 48, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal25 = new Lokaal("GSCHB3.038", "LESLOKAAL", 34, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal26 = new Lokaal("GSCHB3.039", "LESLOKAAL", 60, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal27 = new Lokaal("GSCHB4.005", "LESLOKAAL", 56, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal28 = new Lokaal("GSCHB4.006", "LESLOKAAL", 35, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal29 = new Lokaal("GSCHB4.008", "LESLOKAAL", 34, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal30 = new Lokaal("GSCHB4.011", "LESLOKAAL", 35, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal31 = new Lokaal("GSCHB4.014", "LESLOKAAL", 49, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal32 = new Lokaal("GSCHB4.015", "LESLOKAAL", 49, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal33 = new Lokaal("GSCHB4.016", "LESLOKAAL", 49, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal34 = new Lokaal("GSCHB4.017", "LESLOKAAL", 49, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal35 = new Lokaal("GSCHB4.039", "LESLOKAAL", 60, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal36 = new Lokaal("GSCHB4.041", "LESLOKAAL", 60, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal37 = new Lokaal("GSCHB4.042", "LESLOKAAL", 60, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal38 = new Lokaal("GSCHB1.008", "PC_LOKAAL", 20, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal39 = new Lokaal("GSCHB1.026", "PC_LOKAAL", 24, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal40 = new Lokaal("GSCHB1.029", "PC_LOKAAL", 36, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal41 = new Lokaal("GSCHB1.031", "PC_LOKAAL", 36, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal42 = new Lokaal("GSCHB1.036", "PC_LOKAAL", 32, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal43 = new Lokaal("GSCHB1.037", "PC_LOKAAL", 32, SCHB, CampusSchoonmeersen, Gent);
                //Lokaal lokaal44 = new Lokaal("GSCHB1.032", "PC_LOKAAL", 64);
                Lokaal lokaal45 = new Lokaal("GSCHB4.012", "PC_LOKAAL", 35, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal46 = new Lokaal("GSCHB4.013", "PC_LOKAAL", 42, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal47 = new Lokaal("GSCHB4.036", "PC_LOKAAL", 60, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal48 = new Lokaal("GSCHB1.011", "LAPTOPLOKAAL", 24, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal49 = new Lokaal("GSCHB2.009", "LAPTOPLOKAAL", 28, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal50 = new Lokaal("GSCHB2.010", "LAPTOPLOKAAL", 28, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal51 = new Lokaal("GSCHB2.011", "LAPTOPLOKAAL", 28, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal52 = new Lokaal("GSCHB3.012", "LAPTOPLOKAAL", 28, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal53 = new Lokaal("GSCHB3.013", "LAPTOPLOKAAL", 38, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal54 = new Lokaal("GSCHB3.026", "LAPTOPLOKAAL", 28, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal55 = new Lokaal("GSCHB3.027", "LAPTOPLOKAAL", 28, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal56 = new Lokaal("GSCHB3.028", "LAPTOPLOKAAL", 26, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal57 = new Lokaal("GSCHB3.029", "LAPTOPLOKAAL", 36, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal58 = new Lokaal("GSCHB3.035", "LAPTOPLOKAAL", 28, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal59 = new Lokaal("GSCHB3.036", "LAPTOPLOKAAL", 70, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal60 = new Lokaal("GSCHB3.037", "LAPTOPLOKAAL", 38, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal61 = new Lokaal("GSCHB4.029", "LAPTOPLOKAAL", 25, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal62 = new Lokaal("GSCHB4.026", "IT_LAB", 30, SCHB, CampusSchoonmeersen, Gent);
                Lokaal lokaal63 = new Lokaal("GSCHC0.125", "AUDITORIUM", 288, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal64 = new Lokaal("GSCHC0.155", "AUDITORIUM", 245, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal65 = new Lokaal("GSCHC1.005", "AUDITORIUM", 105, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal66 = new Lokaal("GSCHC1.155", "AUDITORIUM", 393, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal67 = new Lokaal("GSCHC3.010", "AUDITORIUM", 106, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal68 = new Lokaal("GSCHC4.105", "AUDITORIUM", 106, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal69 = new Lokaal("GSCHC4.130", "AUDITORIUM", 113, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal70 = new Lokaal("GSCHC4.135", "AUDITORIUM", 170, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal71 = new Lokaal("GSCHC0.006", "LESLOKAAL", 25, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal72 = new Lokaal("GSCHC0.007", "LESLOKAAL", 25, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal73 = new Lokaal("GSCHC1.003", "LESLOKAAL", 24, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal74 = new Lokaal("GSCHC1.004", "LESLOKAAL", 24, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal75 = new Lokaal("GSCHC1.007", "LESLOKAAL", 29, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal76 = new Lokaal("GSCHC1.008", "LESLOKAAL", 46, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal77 = new Lokaal("GSCHC1.009", "LESLOKAAL", 46, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal78 = new Lokaal("GSCHC1.010", "LESLOKAAL", 46, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal79 = new Lokaal("GSCHC1.011", "LESLOKAAL", 46, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal80 = new Lokaal("GSCHC1.012", "LESLOKAAL", 68, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal81 = new Lokaal("GSCHC2.010", "LESLOKAAL", 66, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal82 = new Lokaal("GSCHC2.012", "LESLOKAAL", 65, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal83 = new Lokaal("GSCHC2.014", "LESLOKAAL", 64, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal84 = new Lokaal("GSCHC2.016", "LESLOKAAL", 62, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal85 = new Lokaal("GSCHC3.006", "LESLOKAAL", 56, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal86 = new Lokaal("GSCHC3.008", "LESLOKAAL", 47, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal87 = new Lokaal("GSCHC3.012", "LESLOKAAL", 30, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal88 = new Lokaal("GSCHC3.013", "LESLOKAAL", 30, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal89 = new Lokaal("GSCHC4.140", "LESLOKAAL", 30, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal90 = new Lokaal("GSCHC1.160", "PC_LOKAAL", 15, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal91 = new Lokaal("GSCHC2.003", "PC_LOKAAL", 40, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal92 = new Lokaal("GSCHC1.045", "TAALLAB", 30, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal93 = new Lokaal("GSCHC0.008", "LAPTOPLOKAAL", 93, SCHC, CampusSchoonmeersen, Gent);
                Lokaal lokaal94 = new Lokaal("GSCHD1.028", "AUDITORIUM", 334, SCHD, CampusSchoonmeersen, Gent);
                Lokaal lokaal95 = new Lokaal("GSCHP1.054", "AUDITORIUM", 288, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal96 = new Lokaal("GSCHP1.212", "AUDITORIUM", 90, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal97 = new Lokaal("GSCHP1.213", "AUDITORIUM", 90, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal98 = new Lokaal("GSCHP1.214", "AUDITORIUM", 90, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal99 = new Lokaal("GSCHP1.105", "LESLOKAAL", 53, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal100 = new Lokaal("GSCHP1.215", "LESLOKAAL", 35, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal101 = new Lokaal("GSCHP0.056", "PC_LOKAAL", 30, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal102 = new Lokaal("GSCHP1.221", "PC_LOKAAL", 20, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal103 = new Lokaal("GSCHP0.061", "LAPTOPLOKAAL", 21, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal104 = new Lokaal("GSCHP0.115", "LAPTOPLOKAAL", 106, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal105 = new Lokaal("GSCHP1.052", "LAPTOPLOKAAL", 30, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal106 = new Lokaal("GSCHP1.055", "LAPTOPLOKAAL", 30, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal107 = new Lokaal("GSCHP1.056", "LAPTOPLOKAAL", 30, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal108 = new Lokaal("GSCHP1.057", "LAPTOPLOKAAL", 30, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal109 = new Lokaal("GSCHP1.217", "LAPTOPLOKAAL", 30, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal110 = new Lokaal("GSCHP1.218", "LAPTOPLOKAAL", 70, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal111 = new Lokaal("GSCHP1.255", "LAPTOPLOKAAL", 18, SCHP, CampusSchoonmeersen, Gent);
                Lokaal lokaal112 = new Lokaal("GAARB0.020", "AUDITORIUM", 142, AARB, CampusAalst, Aalst);
                Lokaal lokaal113 = new Lokaal("GAARB2.002", "AUDITORIUM", 106, AARB, CampusAalst, Aalst);
                Lokaal lokaal114 = new Lokaal("GAARB0.027", "LESLOKAAL", 35, AARB, CampusAalst, Aalst);
                Lokaal lokaal115 = new Lokaal("GAARB0.028", "LESLOKAAL", 35, AARB, CampusAalst, Aalst);
                Lokaal lokaal116 = new Lokaal("GAARB0.029", "LESLOKAAL", 35, AARB, CampusAalst, Aalst);
                Lokaal lokaal117 = new Lokaal("GAARB0.030", "LESLOKAAL", 35, AARB, CampusAalst, Aalst);
                Lokaal lokaal118 = new Lokaal("GAARB0.031", "LESLOKAAL", 35, AARB, CampusAalst, Aalst);
                Lokaal lokaal119 = new Lokaal("GAARB0.032", "LESLOKAAL", 35, AARB, CampusAalst, Aalst);
                Lokaal lokaal120 = new Lokaal("GAARB0.033", "VERGADERZAAL",15, AARB, CampusAalst, Aalst);
                Lokaal lokaal121 = new Lokaal("GAARB1.007", "LESLOKAAL", 33, AARB, CampusAalst, Aalst);
                Lokaal lokaal122 = new Lokaal("GAARB1.008", "LESLOKAAL", 33, AARB, CampusAalst, Aalst);
                Lokaal lokaal123 = new Lokaal("GAARB1.009", "LESLOKAAL", 33, AARB, CampusAalst, Aalst);
                Lokaal lokaal124 = new Lokaal("GAARB1.013", "LESLOKAAL",33, AARB, CampusAalst, Aalst);
                /*Lokaal lokaal125 = new Lokaal("GAARB1.014", "LESLOKAAL", 33);*/
                Lokaal lokaal126 = new Lokaal("GAARB1.015", "LESLOKAAL", 33, AARB, CampusAalst, Aalst);
                Lokaal lokaal127 = new Lokaal("GAARB0.047", "PC_LOKAAL", 30, AARB, CampusAalst, Aalst);
                Lokaal lokaal128 = new Lokaal("GAARB1.023","PC_LOKAAL",30, AARB, CampusAalst, Aalst);

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
                DateTime verleden = new DateTime(2020, 01, 01, 8, 30, 0);
                DateTime date = new DateTime(2020, 05, 13, 8, 30, 0);
                DateTime toekomst = DateTime.Now;//new DateTime(2020, 06, 01, 8, 30, 0);
                //Zichtbaar
                Sessie sessie1 = new Sessie("Inleiding tot Trello", "Een korte inleiding over hoe wij trello zullen gebruiken binnen de opleiding toegepaste informatica.", toekomst.AddDays(2), toekomst.AddDays(2).AddHours(1), lokaal1, lokaal1.AantalPlaatsen, Jonathan, "Jan Janssens", academiejaar2021, "zichtbaar");
                Sessie sessie2 = new Sessie("Uitleg stage, academiejaar 2020-2021", "Uitleg over de hoe's en wat's van stage lopen.", toekomst.AddDays(5), toekomst.AddDays(5).AddHours(2).AddMinutes(30), lokaal2, lokaal2.AantalPlaatsen, Jonathan, "Patrick Hoefman", academiejaar2021, "zichtbaar");
                Sessie sessie3 = new Sessie("Infosessie over het nieuwe curriculum, academiejaar 2020-2021", "beschrijving", toekomst.AddDays(10), toekomst.AddDays(10).AddHours(3), lokaal3, lokaal3.AantalPlaatsen, Jonathan, "", academiejaar2021, "zichtbaar");
                Sessie sessie4 = new Sessie("Hoe maak je een website veilig tegen sql-injecties", "beschrijving", toekomst.AddDays(7), toekomst.AddDays(7).AddHours(1), lokaal4, lokaal4.AantalPlaatsen, Seba, "Bart van Bartelghem", academiejaar2021, "zichtbaar");
                Sessie sessie5 = new Sessie("De wereld van VR", "beschrijving", toekomst.AddDays(1), toekomst.AddDays(1).AddHours(1).AddMinutes(30), lokaal5, lokaal5.AantalPlaatsen, Seba, "Linda V.R. Pommodore", academiejaar2021, "zichtbaar");
                Sessie sessie6 = new Sessie("Inleiding tot UNIX", "beschrijving", toekomst.AddDays(2), toekomst.AddDays(2).AddHours(1), lokaal6, lokaal6.AantalPlaatsen, Seba, "Tim Van Tommelghem", academiejaar2021, "zichtbaar");
                Sessie sessie7 = new Sessie("Infosessie over de bachelor proef", "Een korte en krachtige inleiding tot github. Alles wat men hoef te weten over de werking en de structuur", toekomst.AddDays(5), toekomst.AddDays(5).AddHours(2).AddMinutes(30), lokaal7, lokaal7.AantalPlaatsen, Seba, "Sabine Decock", academiejaar2021, "zichtbaar");
                Sessie sessie8 = new Sessie("The power of UNIX", "Korte sessie over de kracht van de command prompt in unix besturingssystemen", toekomst.AddDays(10), toekomst.AddDays(10).AddHours(1), lokaal62, lokaal62.AantalPlaatsen, Seba, "Micheal Hoefman", academiejaar2021, "zichtbaar");
                Sessie sessie9 = new Sessie("What the future holds for AI", "Korte keynote van Elon Musk over zijn visie van wat er met AI te gebeuren staat", toekomst.AddDays(6), toekomst.AddDays(6).AddHours(1).AddMinutes(45), lokaal63, lokaal63.AantalPlaatsen, Seba, "Elon Musk", academiejaar2021, "zichtbaar");
                Sessie sessie10 = new Sessie("The dangers of fake news", "Korte uitleg over het woord fake news en de gevolgen ervan.", toekomst, toekomst.AddHours(1).AddMinutes(30), lokaal64, lokaal64.AantalPlaatsen, Seba, "Donald Trump",academiejaar2021, "zichtbaar");
                Sessie sessie11 = new Sessie("Inleiding tot Github", "Een inleiding over hoe wij github zullen gebruiken in de opleiding Toegepaste Informatica.", toekomst, toekomst.AddHours(2), lokaal1, lokaal1.AantalPlaatsen, Seba, "Joy Hoefman",academiejaar2021, "zichtbaar");
                Sessie sessie12 = new Sessie("De toekomst van een IT'er.", "beschrijving", toekomst.AddDays(2), toekomst.AddDays(2).AddHours(2), lokaal1, lokaal1.AantalPlaatsen, Seba, "Gina De Clerq",academiejaar2021, "zichtbaar");
                Sessie sessie13 = new Sessie("How 1 hour of work can be better than 3 ", "beschrijving", toekomst.AddDays(2), toekomst.AddDays(2).AddHours(2), lokaal1, lokaal1.AantalPlaatsen, Seba, "Matt D'Avella", academiejaar2021, "zichtbaar");

                //Gesloten
                Sessie sessie14 = new Sessie("Inleiding tot Ruby", "beschrijving", verleden.AddDays(2), verleden.AddDays(2).AddHours(2), lokaal1, lokaal1.AantalPlaatsen, Jonathan, "", academiejaar2021, "gesloten");
                Sessie sessie15 = new Sessie("Inside the mind of a master procrastinator", "beschrijving", verleden.AddDays(2), verleden.AddDays(2).AddHours(2), lokaal1, lokaal1.AantalPlaatsen, Jonathan, "Ted X", academiejaar2021, "gesloten");
                Sessie sessie16 = new Sessie("De opkomende programmeertalen", "Infosessie over de mogelijkheden tot buitenlandse studie of stage", verleden, verleden.AddHours(1).AddMinutes(15), lokaal8, lokaal8.AantalPlaatsen, Seba, "Meer Progra", academiejaar2021, "gesloten");
                Sessie sessie17 = new Sessie("Infosessie internationlisering IT", "beschrijving", verleden, verleden.AddHours(1).AddMinutes(30), lokaal1, lokaal1.AantalPlaatsen, Seba, "", academiejaar2021, "gesloten");
                Sessie sessie18 = new Sessie("Everything about outsourcing", "beschrijving", verleden, verleden.AddHours(2).AddMinutes(15), lokaal1, lokaal1.AantalPlaatsen, Seba, "", academiejaar2021, "gesloten");
                Sessie sessie19 = new Sessie("Functional programming 101", "beschrijving", verleden, verleden.AddHours(3), lokaal1, lokaal1.AantalPlaatsen, Seba, "Tamara Bliskovskafaty", academiejaar2021, "gesloten");
                Sessie sessie20 = new Sessie("De financiële gevolgen van COVID-19", "beschrijving", verleden, verleden.AddHours(1).AddMinutes(45), lokaal1, lokaal1.AantalPlaatsen, Seba, "Matz Sels", academiejaar2021, "gesloten");

                sessie10.AddInschrijving(Jonathan);
                sessie10.AddInschrijving(Ziggy);
                sessie10.AddInschrijving(Kilian);
                
                var sessies = new List<Sessie> { sessie1, sessie2, sessie3, sessie4, sessie5, sessie6, sessie7, sessie8, sessie9, sessie10,
                                                 sessie11, sessie12, sessie13, sessie14, sessie15, sessie16, sessie17, sessie18, sessie19, sessie20 };
                
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
