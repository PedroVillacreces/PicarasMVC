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
        [ForeignKey("CustomerId")]
        public virtual Customer User { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OrderDay { get; set; }
        [Required]
        public int AgentTransportId { get; set; }
        [ForeignKey("AgentTransportId")]
        public virtual AgentTransport AgentTransport { get; set; }
        public ICollection<OrderProduct> Products { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Payments { get; set; }
    }

    public class OrderProduct
    {
        [Key]
        public int OrderProductId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
