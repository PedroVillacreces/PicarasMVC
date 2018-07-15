using System;
using System.Collections.Generic;
using System.Linq;
using Picaras.Model.Entities;

namespace Picaras.Model.ViewModels
{
    public class ProductSize
    {
        public Product Product{ get; set; }
        public IEnumerable<string> Sizes { get; set; }
        public IEnumerable<AgentTransport> Transports { get; set; }
    }
}
