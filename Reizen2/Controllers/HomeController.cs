using Microsoft.AspNetCore.Mvc;
using Reizen2.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Model.Repositories;
using Model.Entities;

namespace Reizen2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ReizenContext context;
        private readonly IWerelddelenRepository werelddelenRepository;

        public HomeController(ILogger<HomeController> logger, IWerelddelenRepository werelddelenRepository)
        {
            _logger = logger;
            this.werelddelenRepository = werelddelenRepository; 
        }

        public IActionResult Index()
        {
            
            
            
            
            return View(werelddelenRepository.GetAll());
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