using Microsoft.AspNetCore.Mvc;
using Reizen2.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Model.Repositories;
using Model.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Reizen2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ReizenContext context;
        private readonly IWerelddelenRepository werelddelenRepository;

        public HomeController(ILogger<HomeController> logger, IWerelddelenRepository werelddelenRepository, ReizenContext context)
        {
            _logger = logger;
            this.werelddelenRepository = werelddelenRepository; 
            this.context = context;
        }

        public IActionResult Index()
        {
            
            
            
            
            return View(werelddelenRepository.GetAll());
        }
       
        public IActionResult Detail(int id)
        {
            var werelddeel = context.Werelddelen.Where(w => w.Id == id).FirstOrDefault();
            ViewBag.naam = werelddeel.Naam;
            return View(werelddelenRepository.GetLanden(id));
        }

        public IActionResult LandDetail(int id)
        {
            var land = context.Landen.Where(l => l.Id == id).FirstOrDefault();
            ViewBag.land = land.Naam;
            return View(werelddelenRepository.GetBestemmingen(id));
        }

        public IActionResult BestemmingDetail(string code)
        {
            
            var bestemming = context.Bestemmingen.Where(r=>r.Code == code).FirstOrDefault();
            ViewBag.bestemming = bestemming.Plaats;
            return View(werelddelenRepository.GetReizen(code));
        }
        
        public IActionResult Boeken(int id, string bestemming)
        {
            var reis = werelddelenRepository.GetReis(id);

            

            
            var boekenViewModel = new BoekenViewModel
            {
                Bestemming = bestemming,
                Reis = reis,
                Klanten = null
            };
           

            var viewModel = new BoekenKlantenViewModel
            {
                BoekenViewModel = boekenViewModel,
                Klanten = null
            };
            HttpContext.Session.SetString("Bestemming", bestemming);
            HttpContext.Session.SetInt32("ReisId", id);
            return View(viewModel);
            
            
        }

        
        public IActionResult KlantZoeken(string naam)                  
        {
            var bestemming = HttpContext.Session.GetString("Bestemming"); 
            var reisId = HttpContext.Session.GetInt32("ReisId");                 

            var reis = werelddelenRepository.GetReis(reisId.GetValueOrDefault());
            var klanten = werelddelenRepository.GetKlanten(naam);

            var boekenViewModel = new BoekenViewModel
            {
                Bestemming = bestemming,        
                Reis = reis,
                Klanten = klanten
            };

            var viewModel = new BoekenKlantenViewModel
            {
                BoekenViewModel = boekenViewModel,
                Klanten = klanten
            };

            return View("BoekenKlanten", viewModel);


        }

        public IActionResult Boeking(int id)
        {
            var bestemming = HttpContext.Session.GetString("Bestemming");
            var reisId = HttpContext.Session.GetInt32("ReisId");
            var klant = werelddelenRepository.GetKlant(id);

            var reis = werelddelenRepository.GetReis((int)reisId);


            var viewModel = new BoekingViewModel
            {
                Reis = reis,
                Bestemming = bestemming,
                Klant = klant
            };
            return View(viewModel);


        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}