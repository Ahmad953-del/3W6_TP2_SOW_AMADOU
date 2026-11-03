namespace NutriVie.ViewModels
{
    public class RecetteCategorieVM
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<RecetteInfoVM>? RecetteInfoVMs { get; set; }
    }
}
