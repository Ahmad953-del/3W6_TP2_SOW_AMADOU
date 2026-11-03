using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NutriVie.ViewModels
{
    public class RecetteInfoVM
    {
        public string Nom { get; set; }
        public int NbrIngrediens { get; set; }
        public int tempsTotal { get; set; }
        [ValidateNever]
        public RecetteCategorieVM? RecetteCategorieVM { get; set; }

    }
}
