using Abp.Domain.Entities;
using System.Collections.Generic;

namespace TrainTickets.Routes
{
    public class Route : Entity<int>
    {
        public virtual string Start { get; set; }
        public virtual string End { get; set; }
        public virtual ICollection<IntermediateStation> IntermediateStations { get; set; }
   
    }

   
}
