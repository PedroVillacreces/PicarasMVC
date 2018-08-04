using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

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
        [Required(ErrorMessage = "Campo Nombre Obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [MaxLength(200)]
        [Required(ErrorMessage = "Campo Apellidos Obligatorio")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Campo Dirección Obligatorio")]
        [MaxLength(200)]
        [Display(Name = "Dirección")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Campo País Obligatorio")]
        [MaxLength(30)]
        [Display(Name = "País")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Campo CP Obligatorio")]
        [MaxLength(10)]
        [Display(Name = "CodPostal")]
        public string PostCode { get; set; }
        [Required(ErrorMessage = "Campo Población Obligatorio")]
        [MaxLength(20)]
        [Display(Name = "Población")]
        public string City { get; set; }
        [Required(ErrorMessage = "Campo Provincia Obligatorio")]
        [MaxLength(20)]
        [Display(Name = "Provincia")]
        public string Region { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "FNacimiento")]
        [Required(ErrorMessage = "Campo Fecha de Nacimiento Obligatorio")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Campo Teléfono Obligatorio")]
        [Phone]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }
        [Remote("DoesEmailExist", "Register", HttpMethod = "POST", ErrorMessage = "Este email ya existe. Por favor elige un usuario nuevo.")]
        [Required(ErrorMessage = "Campo Correo Electrónico Obligatorio")]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }
        [Display(Name="Nombre de Usuario")]
        [Required(ErrorMessage = "Campo Nombre de Usuario Obligatorio")]
        [Remote("DoesUserNameExist", "Register", HttpMethod = "POST", ErrorMessage = "Este usuario ya existe. Por favor elige un usuario nuevo.")]
        public string UserName { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Campo Contraseña Obligatorio")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Las contraseñas deben coincidir !")]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }
        public bool Active { get; set; }
        public string CodeActive { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
