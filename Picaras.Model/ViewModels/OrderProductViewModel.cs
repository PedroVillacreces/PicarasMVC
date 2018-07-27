using System.Collections.Generic;
using Picaras.Model.Entities;

namespace Picaras.Model.ViewModels
{
    public class OrderProductViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
