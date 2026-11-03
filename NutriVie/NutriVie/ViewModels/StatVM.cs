using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NutriVie.Models;

namespace NutriVie.ViewModels
{
    public class StatVM
    {
        [Key]
        public int NbRecettes3Aliments { get; set; }
        public string AlimentPlusCalorique { get; set; }
        [ValidateNever]
        public List<Recettes>? RecettesPlusCourtes { get; set; }
        public double CaloriesRecetteFrancaiseMin { get; set; }
    }
    
}
