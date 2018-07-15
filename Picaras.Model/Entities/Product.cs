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
        [Display(Name = "Producto")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Código Producto")]
        public int ProductCode { get; set; }
        [MaxLength(500)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Required]
        [DefaultValue(0)]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }
        [Display(Name = "Activo")]
        public bool Active { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }
        [MaxLength(100)]
        [Display(Name = "Imagen")]
        public string Picture { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha")]
        public DateTime CreateDateTime { get; set; }
        [Display(Name = "Precio Antiguo")]
        public decimal? OldPrice { get; set; }
        [ForeignKey("CategoryId")]
        [Display(Name = "Categoría")]
        public virtual Category Category  { get; set; }
        [Required]
        [Display(Name = "Categoría")]
        public int CategoryId { get; set; }
        [ForeignKey("SubcategoryId")]
        [Display(Name = "Subcategoría")]
        public virtual Subcategory Subcategory { get; set; }
        [Display(Name = "Subcategoría")]
        public int SubcategoryId { get; set; }
        [DefaultValue(false)]
        [Display(Name = "Outlet")]
        public bool IsOutlet { get; set; }
        [DefaultValue(0)]
        public int NumberOfSales { get; set; }
        [Required]
        public string Size { get; set; }

    }
}
