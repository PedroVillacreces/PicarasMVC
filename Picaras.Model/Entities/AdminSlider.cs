namespace Picaras.Model.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class AdminSlider
    {
        [Key]
        public int AdminSliderId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Image { get; set; }
        [Required]
        [MaxLength(500)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
