using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabNET.Models.Domain;
using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Models.Domain.Sessies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<Sessie> sessies;
            sessies = _sessieRepository.GetAll();
            return View(sessies);
        }

        public IActionResult ToonInfoSessie(int SessieId)
        {
            Sessie sessie = _sessieRepository.GetById(SessieId);
            return View(sessie);
        }

        [HttpPost]
        public IActionResult SchrijfIn(int id, Gebruiker gebruiker) {
            try
            {
                Sessie sessie = _sessieRepository.GetById(id);

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

        [HttpPost]
        public IActionResult SchrijfUit(Gebruiker gebruiker, int id)
        {
            try
            {
                Sessie sessie = _sessieRepository.GetById(id);

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

    }
}