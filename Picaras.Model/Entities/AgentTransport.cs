
namespace Picaras.Model.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AgentsTransport")]
    public class AgentTransport
    {
        [Key]
        public int AgentTransportId { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Agencia")]
        public string AgentName { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }

    }
}
