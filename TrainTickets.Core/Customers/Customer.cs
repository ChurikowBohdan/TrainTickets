using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Tickets;

namespace TrainTickets.Customers
{
   public class Customer : Entity <int>
    {
        public virtual string Name { get; set;}
        public virtual string SecondName { get; set; }
        public virtual int PassportId { get; set; }
        public virtual int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }

    }
}
