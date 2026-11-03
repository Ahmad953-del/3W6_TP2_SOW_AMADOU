using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NutriVie.Models
{
    public class AlimentRecette
    {
        [Key]
        public int RecetteId { get; set; }
        [ValidateNever]
        public Recettes? Recette { get; set; }

        public int AlimentId { get; set; }
        [ValidateNever]
        public Aliment? Aliment { get; set; }

        [Range(0.1, 10000)]
        public double Poids { get; set; }
    }
}
