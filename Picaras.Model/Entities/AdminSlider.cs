namespace Picaras.Model.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class AdminSlider
    {
        [Key]
        public int AdminSliderId { get; set; }
        [Required]
        [MaxLength(500)]
        [Display(Name = "Imagen")]
        public string Image { get; set; }
        [Required]
        [MaxLength(500)]
        [Display(Name = "Titulos")]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        [Display(Name = "Descripciones")]
        public string Description { get; set; }
    }
}
