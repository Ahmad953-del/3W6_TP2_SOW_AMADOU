using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
namespace NutriVie.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Le nom du service est requis.")]
        [StringLength(30)]
        public string Nom { get; set; }
        [Required(ErrorMessage = "La description est requise.")]
        public string Description { get; set; }
    }
}
