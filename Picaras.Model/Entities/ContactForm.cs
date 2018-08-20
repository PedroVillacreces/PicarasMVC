using Picaras.Model.CustomDataNotations;
using System.ComponentModel.DataAnnotations;

namespace Picaras.Model.Entities
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Campo Nombre Obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo Apellidos Obligatorio")]
        [Display(Name = "Apellidos")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Campo Teléfono Obligatorio")]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Campo Correo Electrónico Obligatorio")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Mensaje Obligatorio")]
        [Display(Name = "Mensaje")]
        public string Message { get; set; }
        [Required(ErrorMessage = "Campo Asunto Obligatorio")]
        [Display(Name = "Asunto")]
        public string Subject { get; set; }
        [CheckBoxRequired(ErrorMessage = "Por favor, lea y acepte los términos y condiciones de privacidad")]
        [Display(Name = "Terminos y Condiciones")]        
        public bool IsTermsAccepted { get; set; }
    }
}
