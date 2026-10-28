using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NutriVie.Models
{
    public class Categorie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [ValidateNever]
        public List<Recettes>? Recettes { get; set; }

        [Display(Name = "Catégorie")]
        public int CategorieId { get; set; }


    }
}
