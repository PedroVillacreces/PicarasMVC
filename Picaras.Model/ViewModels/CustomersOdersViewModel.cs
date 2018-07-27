using System.Collections.Generic;
using Picaras.Model.Entities;

namespace Picaras.Model.ViewModels
{
    public class CustomersOdersViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
