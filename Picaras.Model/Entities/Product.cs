namespace Picaras.Model.Entities
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [DefaultValue(0)]
        public int Quantity { get; set; }
        public bool Active { get; set; }
        [Required]
        public decimal Price { get; set; }
        [MaxLength(100)]
        public string Picture { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDateTime { get; set; }
        public decimal? OldPrice { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category  { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("SubcategoryId")]
        public virtual Subcategory Subcategory { get; set; }
        public int SubcategoryId { get; set; }
        [DefaultValue(false)]
        public bool IsOutlet { get; set; }
    }
}
