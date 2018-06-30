using System.ComponentModel.DataAnnotations;

namespace Picaras.Model.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(50)]
        [Required]
        [Display(Name = "Categoría")]
        public string Name { get; set; }
        [MaxLength(500)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
    }
}
