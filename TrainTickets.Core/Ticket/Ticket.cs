using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Trains;

namespace TrainTickets.Tickets
{
   public class Ticket : Entity<int>
    {
        public virtual string TicketType { get; set; }
        public virtual int Carriage { get; set; }
        public virtual int Place { get; set; }

        public virtual int TrainId { get; set; }
        [ForeignKey("TrainId")]
        public virtual Train Train { get; set; }


    }
}
