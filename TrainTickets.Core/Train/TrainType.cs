using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets {
	public class TrainType :Entity<int> {
		public string Name { get; set; }
	}
}
