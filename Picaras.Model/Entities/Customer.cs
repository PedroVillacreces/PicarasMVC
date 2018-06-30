using System.ComponentModel.DataAnnotations.Schema;

namespace Picaras.Model.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [MaxLength(50)]
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [MaxLength(200)]
        [Required]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Dirección")]
        public string Address { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "País")]
        public string Country { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name = "CodPostal")]
        public string PostCode { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "Población")]
        public string City { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "Provincia")]
        public string Region { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "FNacimiento")]
        public DateTime Birthday { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }

    }
}
