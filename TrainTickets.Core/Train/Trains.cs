using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TrainTickets.Routes;
using TrainTickets.Tickets;

namespace TrainTickets.Trains
{
    public class Train : Entity<int>
    {
        public virtual string TrainType { get; set; }

        public virtual int ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public virtual Schedule Schedule { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
    
}
