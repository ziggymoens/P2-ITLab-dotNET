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
            Gebruiker aangemeld = _gebruikerRepository.GetByGebruikersnaam(User.Identity.Name);
            IEnumerable<Sessie> sessies;
            if (User.IsInRole("Verantwoordelijken"))
            {
                sessies = _sessieRepository.GetByZichtbaarStatus(aangemeld);
            }
            else
            {
                sessies = _sessieRepository.GetByZichtbaarStatus(null);
            }
            ViewData["aangemelde"] = aangemeld;
            return View(sessies);
        }

        public IActionResult ToonInfoSessie(int id)
        {
            Sessie s = _sessieRepository.GetById(id);
            ViewData["Datum"] = s.Datum < DateTime.Now;
            Gebruiker aangemeld = _gebruikerRepository.GetByGebruikersnaam(User.Identity.Name);
            ViewData["aangemelde"] = aangemeld;
            return View(s);
        }

        [Authorize(Policy = "Gebruiker")]
        //[HttpPost]
        public IActionResult SchrijfIn(int id)
        {
/*            try
            {*/
                Sessie sessie = _sessieRepository.GetById(id);
                Gebruiker gebruiker = _gebruikerRepository.GetByGebruikersnaam(User.Identity.Name);
                sessie.AddInschrijving(gebruiker);
                _sessieRepository.SaveChanges();
                TempData["message"] = $"U bent succesvol ingeschreven voor {sessie.Titel}, op {sessie.Datum.ToShortDateString()}.";
            /*}
            catch
            {
                TempData["error"] = $"Er is iets misgelopen, u bent niet ingeschreven.";
            }*/
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

        [Authorize(Policy = "Verantwoordelijken")]
        public IActionResult GeefOpenbareSessies()
        {
            try
            {
                Gebruiker gebruiker = _gebruikerRepository.GetByGebruikersnaam(User.Identity.Name);
                return View(_sessieRepository.GetOpenbareSessies(gebruiker));
            }
            catch (Exception)
            {
                TempData["error"] = "Er is iets misgelopen, er zijn geen sessies opgehaald.";
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Policy = "Verantwoordelijken")]
        [HttpPost]
        public IActionResult ZetSessieOpen(int id)
        {
            try
            {
                Sessie sessie = _sessieRepository.GetById(id);
                Gebruiker gebruiker = _gebruikerRepository.GetByGebruikersnaam(User.Identity.Name);
                sessie.setSessieState("open");
                sessie.Inschrijvingen.FirstOrDefault(e => e.Gebruiker == gebruiker).StatusAanwezigheid = true;
                _sessieRepository.SaveChanges();
                TempData["message"] = $"De sessie {sessie.Titel} is geopend, er kunnen nu aanwezigheden worden geregistreerd";
                return RedirectToAction(nameof(AanwezighedenRegistrerenBarcode), new { id });
            }
            catch (Exception)
            {
                TempData["error"] = $"Er is iets misgelopen, de sessie werd niet geopend.";
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Verantwoordelijken")]
        public IActionResult ToonOpenSessie(int id)
        {
            try
            {
                Sessie sessie = _sessieRepository.GetById(id);
                Gebruiker gebruiker = _gebruikerRepository.GetByGebruikersnaam(User.Identity.Name);
                return RedirectToAction(nameof(AanwezighedenRegistrerenBarcode), new { id });
            }
            catch (Exception)
            {
                TempData["error"] = $"Er is iets misgelopen, de sessie kan niet getoond worden.";
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Verantwoordelijken")]
        public IActionResult AanwezighedenRegistrerenBarcode(int id)
        {
            Sessie sessie = _sessieRepository.GetById(id);
            ViewData["sessieId"] = id;
            ViewData["ingeschrevenen"] = sessie.Inschrijvingen;
            return View(new AanwezigheidViewModelBarcode(sessie));
        }


        [Authorize(Policy = "Verantwoordelijken")]
        [HttpPost]
        public IActionResult AanwezighedenRegistrerenBarcode(int id, AanwezigheidViewModelBarcode aanwezigheidViewModel)
        {
            try
            {
                Sessie s = _sessieRepository.GetById(id);
                Gebruiker g = _gebruikerRepository.GetByBarCode(aanwezigheidViewModel.Barcode);
                IEnumerable<Gebruiker> ingeschreven = s.Inschrijvingen.Select(e => e.Gebruiker);
                if (ingeschreven.Contains(g))
                {
                    Inschrijving ins = s.Inschrijvingen.FirstOrDefault(e => e.Gebruiker == g);
                    ins.ZetAanwezigheid(true);
                    _sessieRepository.SaveChanges();
                }
                else
                {
                    Inschrijving ins = new Inschrijving(g, s);
                    s.Inschrijvingen.Add(ins);
                    ins.ZetAanwezigheid(true);
                    _sessieRepository.SaveChanges();
                }
                TempData["message"] = $"De gebruiker is aangemeld bij deze sessie";
                return RedirectToAction(nameof(AanwezighedenRegistrerenBarcode));
            }
            catch
            {
                TempData["error"] = $"Er is iets migelopen, we konden deze persoon niet aanwezig zetten";
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Verantwoordelijken")]
        public IActionResult AanwezighedenRegistrerenGebruikersnaam(int id)
        {
            Sessie sessie = _sessieRepository.GetById(id);
            return View(new AanwezigheidViewModelGebruikersnaam(sessie));
        }

        [Authorize(Policy = "Verantwoordelijken")]
        [HttpPost]
        public IActionResult AanwezighedenRegistrerenGebruikersnaam(int id, AanwezigheidViewModelGebruikersnaam aanwezigheidViewModel)
        {
            try
            {
                Sessie s = _sessieRepository.GetById(id);
                Gebruiker g = _gebruikerRepository.GetByGebruikersnaam(aanwezigheidViewModel.Gebruikersnaam);
                IEnumerable<Gebruiker> ingeschreven = s.Inschrijvingen.Select(e => e.Gebruiker);
                if (ingeschreven.Contains(g))
                {
                    Inschrijving ins = s.Inschrijvingen.FirstOrDefault(e => e.Gebruiker == g);
                    ins.ZetAanwezigheid(true);
                    _sessieRepository.SaveChanges();
                }
                else
                {
                    Inschrijving ins = new Inschrijving(g, s);
                    s.Inschrijvingen.Add(ins);
                    ins.ZetAanwezigheid(true);
                    _sessieRepository.SaveChanges();
                }
                TempData["message"] = $"De gebruiker is aangemeld bij deze sessie";
                return RedirectToAction(nameof(AanwezighedenRegistrerenBarcode));
            }
            catch
            {
                TempData["error"] = $"Er is iets migelopen, we konden deze persoon niet aanwezig zetten";
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Verantwoordelijken")]
        //[HttpPost]
        public IActionResult SessieSluiten(int id)
        {
            try
            {
                Sessie s = _sessieRepository.GetById(id);
                s.setSessieState("gesloten");
                _sessieRepository.SaveChanges();
                TempData["message"] = $"De sessie {s.Titel} is correct gesloten";                
            }
            catch
            {
                TempData["error"] = $"Er is iets misgelopen, de sessie is niet gesloten geweest";
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Iedereen")]
        public IActionResult GeefFeedbackOpties()
        {
            try
            {
                Gebruiker g = _gebruikerRepository.GetByGebruikersnaam(User.Identity.Name);
                return View(_sessieRepository.GetFeedbackOpties(g));
            }
            catch
            {
                TempData["error"] = "Er is iets misgelopen, er zijn geen sessies opgehaald.";
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Policy = "Iedereen")]
        public IActionResult ToonFeedback(int id)
        {
            Sessie sessie = _sessieRepository.GetById(id);
            if (sessie == null)
            {
                return NotFound();
            }
            ViewData["Sessie"] = sessie.Titel;
            return View(_feedbackRepository.GetBySessie(sessie));
        }

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

        [Authorize(Policy = "Iedereen")]
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