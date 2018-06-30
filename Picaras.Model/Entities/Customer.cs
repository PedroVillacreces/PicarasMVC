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
        public string Name { get; set; }
        [MaxLength(200)]
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
        [Required]
        [MaxLength(30)]
        public string Country { get; set; }
        [Required]
        [MaxLength(10)]
        public string PostCode { get; set; }
        [Required]
        [MaxLength(20)]
        public string City { get; set; }
        [Required]
        [MaxLength(20)]
        public string Region { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthday { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
