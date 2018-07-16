using System.ComponentModel.DataAnnotations;

namespace Picaras.Model.Entities
{
    public class ContactForm
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Apellidos")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Mensaje")]
        public string Message { get; set; }
        [Required]
        [Display(Name = "Asunto")]
        public string Subject { get; set; }
    }
}
