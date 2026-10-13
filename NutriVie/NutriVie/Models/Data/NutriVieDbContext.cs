using Microsoft.EntityFrameworkCore;
namespace NutriVie.Models.Data
{
    public class NutriVieDbContext : DbContext
    {
        public NutriVieDbContext(DbContextOptions<NutriVieDbContext> options) : base(options) { }

        public DbSet<Service> Services { get; set; }
        public DbSet<Recettes> Recettes { get; set; }
        public DbSet<Categorie> Categorie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categorie>().HasData(
       new Categorie() { Id = 1, Nom = "Française" },
       new Categorie() { Id = 2, Nom = "Indienne" },
       new Categorie() { Id = 3, Nom = "Africaine" },
       new Categorie() { Id = 4, Nom = "Italienne" },
       new Categorie() { Id = 5, Nom = "Orientale" });

            modelBuilder.Entity<Recettes>().HasData(
                    new Recettes() { Id = 1, Nom = "Boeuf bourguignon", Description = "Ragoût traditionnel français au boeuf et vin rouge.", TempsPreparation = 30, TempsCuisson = 180, Image = "Boeuf_bourguignon.jpg", CategorieId = 1 },
                    new Recettes() { Id = 2, Nom = "Quiche lorraine", Description = "Tarte salée avec bacon, oeufs et fromage.", TempsPreparation = 20, TempsCuisson = 45, Image = "Quiche_loraine.jpg", CategorieId = 1 },
                    new Recettes() { Id = 3, Nom = "Poulet tikka masala", Description = "Poulet mariné dans une sauce crémeuse épicée.", TempsPreparation = 40, TempsCuisson = 35, Image = "Poulet_tikka_masala.jpg", CategorieId = 2 },
                    new Recettes() { Id = 4, Nom = "Poulet au beurre", Description = "Poulet tendre dans une sauce tomate et beurre.", TempsPreparation = 25, TempsCuisson = 40, Image = "Poulet_au_beurre.jpg", CategorieId = 2 },
                    new Recettes() { Id = 5, Nom = "Poulet yassa", Description = "Poulet mariné au citron et aux oignons.", TempsPreparation = 35, TempsCuisson = 50, Image = "Poulet_Yassa.jpg", CategorieId = 3 },
                    new Recettes() { Id = 6, Nom = "Riz jaune", Description = "accompagnement traditionnel en Afrique du Sud.", TempsPreparation = 10, TempsCuisson = 25, Image = "Riz_jaune.jpg", CategorieId = 3 },
                    new Recettes() { Id = 7, Nom = "Lasagne", Description = "Pâtes gratinées avec viande et sauce tomate.", TempsPreparation = 45, TempsCuisson = 60, Image = "Lasagne.jpg", CategorieId = 4 },
                    new Recettes() { Id = 8, Nom = "Risotto aux champignons", Description = "Riz crémeux italien aux champignons.", TempsPreparation = 15, TempsCuisson = 35, Image = "Risotto_Champignons.jpg", CategorieId = 4 },
                    new Recettes() { Id = 9, Nom = "Couscous yoyal", Description = "Semoule servie avec légumes et viandes variées.", TempsPreparation = 40, TempsCuisson = 90, Image = "Couscous_royal.jpg", CategorieId = 5 },
                    new Recettes() { Id = 10, Nom = "Shawarma", Description = "Viande marinée grillée servie dans un pain pita.", TempsPreparation = 25, TempsCuisson = 30, Image = "Shawarma.jpg", CategorieId = 5 });
        }

    }
}
