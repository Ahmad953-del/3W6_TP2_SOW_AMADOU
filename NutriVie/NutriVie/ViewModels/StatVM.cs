using NutriVie.Models;

namespace NutriVie.ViewModels
{
    public class StatVM
    {
        public int NbRecettes3Aliments { get; set; }
        public string AlimentPlusCalorique { get; set; }
        public List<RecetteTempsVM> RecettesPlusCourtes { get; set; }
        public double CaloriesRecetteFrancaiseMin { get; set; }
    }
    public class RecetteTempsVM
    {
        public string Nom { get; set; }
        public int TempsTotal { get; set; }
    }
}
