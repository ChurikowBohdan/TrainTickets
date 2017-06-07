using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Trains.Dto;

namespace TrainTickets.Trains {
	public interface ITrainService : IApplicationService {

		//TrainTypes
		ICollection<TrainTypeDto> GetTrainTypes();
		TrainTypeDto GetTrainType(int id);
		void DeleteTrainType(int id);
		void UpdateTrainType(TrainTypeDto TrainType);
		void AddTrainType(TrainTypeDto TrainType);

		//Train
		ICollection<TrainDto> GetTrains();
		TrainDto GetTrain(int id);
		void DeleteTrain(int id);
		void UpdateTrain(TrainDto train);
		void AddTrain(TrainDto train);

	}
}
