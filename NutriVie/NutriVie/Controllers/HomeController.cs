using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NutriVie.Models;
using NutriVie.Models.Data;

namespace NutriVie.Controllers
{
    
    public class HomeController : Controller
    {

        // Variable privée pour stocker le contexte de base de données
        private NutriVieDbContext _context;
        // Le constructeur reçoit automatiquement le DbContext grâce à l'injection de dépendances
        public HomeController(NutriVieDbContext context)
        {
            _context = context;
        }
        // Modification de l'action Index
        public IActionResult Index()
        {
            // Récupère la liste de tous les services dans la base de données
            List<Service> listeService = _context.Services.ToList();

            // Envoie la liste directement à la vue index.cshtml
            return View(listeService);
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
