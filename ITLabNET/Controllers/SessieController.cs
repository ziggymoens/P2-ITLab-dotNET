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
    [Authorize(Policy = "Gebruiker")]
    public class SessieController : Controller
    {
        private readonly ISessieRepository _sessieRepository;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IGebruikerRepository _gebruikerRepository;
        #region constructor
        public SessieController(ISessieRepository sessieRepository, IFeedbackRepository feedbackRepository, IGebruikerRepository gebruikerRepository)
        {
            this._sessieRepository = sessieRepository;
            this._feedbackRepository = feedbackRepository;
            this._gebruikerRepository = gebruikerRepository;

        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
        #region sessie openen

        #endregion
    }
}