using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Picaras.Model.Entities;

namespace Picaras.Model.ViewModels
{
    public class ProductCartViewModel
    {
        public Product Product { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public IList<AgentTransport> AgentTransport { get; set; }
       
    }
}
