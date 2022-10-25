using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrgaTournoi.Data;
using OrgaTournoi.Models;
using System.Diagnostics;

namespace OrgaTournoi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OrgaTournoiContext _context;


        public HomeController(ILogger<HomeController> logger, OrgaTournoiContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var jeux = _context.Jeu.ToList();
            var evenementParJeux = _context.Evenement.ToList();
            foreach (var jeuxItem in jeux)
            {
                Console.WriteLine(jeuxItem.Nom);
                
                foreach (var item in jeuxItem.Evenements)
                {
                    Console.WriteLine(item.Nom);
                }
            }
          /*  foreach (var evenement in evenementParJeux)
            {
                Console.WriteLine(evenement.Nom);
            }*/

            return View(jeux);
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