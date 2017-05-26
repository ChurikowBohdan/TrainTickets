using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets.Routes
{
    public class IntermediateStation : Entity<int>
    {
        public virtual string NameStation { get; set; }
        public virtual string Country { get; set; }
        public virtual string City { get; set; }
        public virtual string Address { get; set; }
    }
}
