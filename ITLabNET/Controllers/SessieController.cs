using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain;
using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITLabNET.Controllers
{
    
    public class SessieController : Controller
    {
        private readonly ISessieRepository _sessieRepository;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IGebruikerRepository _gebruikerRepository;
        #region constructor
        public SessieController(ISessieRepository sessieRepository, IFeedbackRepository feedbackRepository, IGebruikerRepository gebruikerRepository)
        {
            _sessieRepository = sessieRepository;
            _feedbackRepository = feedbackRepository;
            _gebruikerRepository = gebruikerRepository;

        }
        #endregion

        public IActionResult Index()
        {
            IEnumerable<Sessie> sessies = _sessieRepository.GetAll();

            Gebruiker aangemeld = _gebruikerRepository.GetByGebruikersnaam(User.Identity.Name);
            ViewData["aangemelde"] = aangemeld;

            var filteropties = new List<string> { "Alle", "Maand", "Week", "Vandaag"};
            ViewData["filter"] = new SelectList(filteropties);

            IEnumerable<Inschrijving> ingeschreven = sessies.Select(e => e.Inschrijvingen.FirstOrDefault(a => a.Gebruiker == aangemeld));
            IEnumerable<Sessie> ingeschrevenSessie = ingeschreven.Select(e => e.Sessie);

            return View(sessies);
        }

        public IActionResult ToonInfoSessie(int id)
        {
            Sessie s = _sessieRepository.GetById(id);
            ViewData["Datum"] = s.Datum < DateTime.Now;
            ViewData["Ingeschreven"] = User.Identity.Name;
            return View(s);
        }

        [Authorize(Policy = "Gebruiker")]
        //[HttpPost]
        public IActionResult SchrijfIn(int id)
        {
            try
            {
                Sessie sessie = _sessieRepository.GetById(id);
                Gebruiker gebruiker = _gebruikerRepository.GetByGebruikersnaam(User.Identity.Name);
                sessie.AddInschrijving(gebruiker);
                _sessieRepository.SaveChanges();
                TempData["message"] = $"U bent succesvol ingeschreven voor {sessie.Titel}, op {sessie.Datum}.";
            }
            catch
            {
                TempData["error"] = $"Er is iets misgelopen, u bent niet ingeschreven.";
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Gebruiker")]
        //[HttpPost]
        public IActionResult SchrijfUit(int id)
        {
            try
            {
                Sessie sessie = _sessieRepository.GetById(id);
                Gebruiker gebruiker = _gebruikerRepository.GetByGebruikersnaam(User.Identity.Name);
                sessie.RemoveInschrijving(gebruiker);

                _sessieRepository.SaveChanges();
                TempData["message"] = $"U bent succesvol uitgeschreven voor {sessie.Titel}.";
            }
            catch
            {
                TempData["error"] = $"Er is iets misgelopen, u bent niet uitgeschreven.";
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Verantwoordelijke")]
        public IActionResult OpenSessie()
        {
            try
            {
                Gebruiker gebruiker = _gebruikerRepository.GetByGebruikersnaam(User.Identity.Name);
                return View(_sessieRepository.GetByVerantwoordelijke(gebruiker));
            }
            catch (Exception)
            {
                TempData["error"] = "Er is iets misgelopen, er zijn geen sessies opgehaald.";
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Policy = "Verantwoordelijke")]
        [HttpPost]
        public IActionResult OpenenSessie(int id)
        {
            try
            {
                Sessie sessie = _sessieRepository.GetById(id);
                sessie.setSessieState("open");
                _sessieRepository.SaveChanges();
                TempData["message"] = $"De sessie {sessie.Titel} is geopend, er kunnen nu aanwezigheden worden geregistreerd";
            }
            catch (Exception)
            {
                TempData["error"] = $"Er is iets misgelopen, de sessie werd niet geopend.";
            }
            return RedirectToAction(nameof(Index));
        }

    }
}