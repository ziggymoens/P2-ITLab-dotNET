using ITLabNET.Models.Domain;
using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
using ITLabNET.Models.SessieViewModels;
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

            var filteropties = new List<string> { "Alle", "Maand", "Week", "Vandaag" };
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
        public IActionResult GeefOpenbareSessies()
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
        public IActionResult ZetSessieOpen(int id)
        {
            try
            {
                Sessie sessie = _sessieRepository.GetById(id);
                Console.WriteLine(id);
                sessie.setSessieState("open");
                _sessieRepository.SaveChanges();
                TempData["message"] = $"De sessie {sessie.Titel} is geopend, er kunnen nu aanwezigheden worden geregistreerd";
                return RedirectToAction(nameof(AanwezighedenRegistreren);
            }
            catch (Exception)
            {
                TempData["error"] = $"Er is iets misgelopen, de sessie werd niet geopend.";
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Verantwoordelijke")]
        public IActionResult AanwezighedenRegistreren(int id)
        {
            Sessie sessie = _sessieRepository.GetById(id);
            Console.WriteLine(id);
            return View(new AanwezigheidViewModel(sessie));
        }

        
        [Authorize(Policy = "Verantwoordelijke")]
        [HttpPost, ActionName("AanwezighedenRegistreren")]
        public IActionResult AanwezighedenRegistrerenBarcode(int id, AanwezigheidViewModel aanwezigheidViewModel)
        {
            Sessie s = _sessieRepository.GetById(id);
            Gebruiker g = _gebruikerRepository.GetByBarCode(aanwezigheidViewModel.Barcode);
            IEnumerable <Gebruiker> ingeschreven = s.Inschrijvingen.Select(e => e.Gebruiker);
            if (ingeschreven.Contains(g))
            {
                Inschrijving ins = s.Inschrijvingen.FirstOrDefault(e => e.Gebruiker == g);                
                ins.ZetAanwezigheid(true);
                _sessieRepository.SaveChanges();
            }
           return RedirectToAction(nameof(AanwezighedenRegistreren));
        }


        [Authorize(Policy = "Verantwoordelijke")]
        public IActionResult ToonFeedback()
        {
            try
            {
                Gebruiker g = _gebruikerRepository.GetByGebruikersnaam(User.Identity.Name);
                return View(_sessieRepository.GetByVerantwoordelijke(g));
            }
            catch
            {
                TempData["error"] = "Er is iets misgelopen, er zijn geen sessies opgehaald.";
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Policy = "Gebruiker")]
        public IActionResult GeefFeedbackOpties()
        {
            try
            {
                Gebruiker g = _gebruikerRepository.GetByGebruikersnaam(User.Identity.Name);
                return View(_sessieRepository.GeefAanwezigeSessiesGebruiker(g));
            }
            catch
            {
                TempData["error"] = "Er is iets misgelopen, er zijn geen sessies opgehaald.";
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Policy = "Gebruiker")]
        public IActionResult GeefFeedback(int id)
        {
            Sessie sessie = _sessieRepository.GetById(id);
            if (sessie == null)
            {
                return NotFound();
            }
            ViewData["Sessie"] = sessie.Titel;

            return View(new FeedbackViewModel(sessie));
        }

        [Authorize(Policy = "Gebruiker")]
        [HttpPost]
        public IActionResult GeefFeedback(int id, FeedbackViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Gebruiker gebruiker = _gebruikerRepository.GetByGebruikersnaam(User.Identity.Name);
                    Sessie sessie = _sessieRepository.GetById(id);
                    Feedback feedback = new Feedback(sessie, gebruiker, viewmodel.Tekst, DateTime.Now);
                    sessie.AddFeedback(feedback);
                    _feedbackRepository.Add(feedback);
                    _feedbackRepository.SaveChanges();
                    _sessieRepository.SaveChanges();
                TempData["message"] = $"Uw feedback werd toegevoegd aan de sessie";
                }
                catch 
                {
                    TempData["error"] = $"Er is iets misgelopen, er is geen feedback toegevoegd.";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
/*
        [Authorize(Policy = "Verantwoordelijke")]
        [HttpPost]
        public IActionResult RegistreerAanwezigheid(int id)
        {
            Sessie s = _sessieRepository.GetById(id);
            
            return View(s);
        }*/

    }
}