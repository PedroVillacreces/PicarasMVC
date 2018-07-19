using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
