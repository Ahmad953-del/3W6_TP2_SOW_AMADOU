using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NutriVie.Models;
using NutriVie.Models.Data;

namespace NutriVie.Controllers
{
    
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            List<Service> listService = new List<Service>();

            return View(listService);
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
