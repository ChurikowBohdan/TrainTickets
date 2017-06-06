using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets {
	public class Order : Entity<int> {

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }

		public string PasportNumber { get; set; }
		public int DispatchingStationId { get; set; }
		public int ArrivalStationId { get; set; }
		public DateTime DispatchingTime { get; set; }
		public decimal Price { get; set; }

		//[ForeignKey("DispatchingStationId")]
		public virtual Station DisaptchingStation { get; set; }

		//[ForeignKey("ArrivalStationId")]
		public virtual Station ArrivalStation { get; set; }
	}
}
