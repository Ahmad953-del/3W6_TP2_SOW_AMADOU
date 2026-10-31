using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using NutriVie.Models.Data;
using NutriVie.ViewModels;

namespace NutriVie.Controllers
{
    public class StatsController : Controller
    {
        private readonly NutriVieDbContext _context;
        public StatsController(NutriVieDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var vm = new StatVM();
            // 1. Recettes avec  3 aliments  Count 
            vm.NbRecettes3Aliments = _context.Recettes
                .Count(r => r.AlimentRecettes.Count == 3);

            // 2. Aliment le plus calorique -> orderbaByDescending + First
            vm.AlimentPlusCalorique = _context.Aliments
                .OrderByDescending(a => a.CaloriesPour100g)
                .First().Nom;

            // 3. 4 Recettes au temps total le plus court OrderBy + Take + Select 
            vm.RecettesPlusCourtes = _context.Recettes
                .OrderBy(r => r.TempsPreparation + r.TempsCuisson)
                .Take(4)
                .Select(r => new RecetteTempsVM
                {
                    Nom = r.Nom,
                    TempsTotal = r.TempsPreparation + r.TempsCuisson
                }).ToList();
            // 4.) Calories de la recette française la moins calorique -> Where, Min, Sum 
            vm.CaloriesRecetteFrancaiseMin = _context.Recettes
                .Where(r => r.Categorie.Nom == "Française") // à adapter
                .Min(r => r.AlimentRecettes
                .Sum( a => a.Aliment.CaloriesPour100g * a.Poids /100.0));
            return View(vm);
        }
    }
}
