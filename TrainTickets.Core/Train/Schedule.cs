using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Routes;

namespace TrainTickets.Trains
{
    public class Schedule : Entity<int>
    {
        public virtual DateTime Date { get; set; }
        public virtual DateTime TimeOut { get; set; }
        public virtual DateTime TimeArrival { get; set; }
        public virtual int RouteId { get; set; }
        [ForeignKey("RouteId")]
        public virtual Route Route { get; set; }
        public virtual ICollection<Train> Trains { get; set; }
        public virtual ICollection<Route> Routes { get; set; }

    }
}
