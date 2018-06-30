namespace Picaras.Model.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;
    public class Subcategory
    {
        [Key]
        public int SubcategoryId { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Subcategoría")]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [DefaultValue(1)]
        [Display(Name = "Categoría")]
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual  Category Category { get; set; }
    }
}
