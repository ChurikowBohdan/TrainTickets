using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets {
	public class Train : Entity<int> {

		public string Number { get; set; }
		public int PlacesCount { get; set; }
		public int TrainTypeId { get; set; }

		//[ForeignKey("TrainTypeId")]
		public virtual TrainType TrainType { get; set; }
	}
}
