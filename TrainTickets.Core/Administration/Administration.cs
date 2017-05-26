using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets.AdministrationArea
{
  public  class Administration : Entity <int>
    {
        public virtual string CustomerName { get; set; }
        public virtual string SecondName { get; set; }
        public virtual int Phone { get; set; }
        public virtual string Status { get; set; }
    }
}
