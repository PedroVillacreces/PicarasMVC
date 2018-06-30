using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Picaras.Model.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public Customer User { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OrderDay { get; set; }
        [Required]
        public int AgentTransportId { get; set; }
        [Required]
        public AgentTransport AgentTransport { get; set; }
        [Required]
        public int ProductId { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
