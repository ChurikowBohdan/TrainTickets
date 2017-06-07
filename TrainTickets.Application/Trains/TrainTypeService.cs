using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Trains.Dto;

namespace TrainTickets.Trains {
	public class TrainService : ApplicationService, ITrainService {

		private readonly IRepository<TrainType> _trainTypeRepository;
		private readonly IRepository<Train> _trainRepository;

		public TrainService(
			IRepository<TrainType> trainTypeRepository,
			IRepository<Train> trainRepository
		) {
			_trainTypeRepository = trainTypeRepository;
			_trainRepository = trainRepository;
		}

		public void AddTrain(TrainDto trainDto) {
			var train = trainDto.MapTo<Train>();
			_trainRepository.Insert(train);
		}

		public void AddTrainType(TrainTypeDto trainTypeDto) {
			var trainType = trainTypeDto.MapTo<TrainType>();
			_trainTypeRepository.Insert(trainType);
		}

		public void DeleteTrain(int id) {
			_trainRepository.Delete(id);
		}

		public void DeleteTrainType(int id) {
			_trainTypeRepository.Delete(id);
		}

		public TrainDto GetTrain(int id) {
			var train = _trainRepository.Get(id);
			var trainDto = train.MapTo<TrainDto>();
			trainDto.TrainTypeName = train.TrainType.Name;
			trainDto.AvailableTrainTypes = _trainTypeRepository.GetAll().ToList().MapTo<ICollection<TrainTypeDto>>();
			return trainDto;
		}

		public ICollection<TrainDto> GetTrains() {
			var trains = _trainRepository.GetAll();
			var trainsDto =  trains.MapTo <ICollection<TrainDto>>();
			foreach(var train in trains) {
				var trainDto = trainsDto.First(t => t.Id == train.Id);
				trainDto.TrainTypeName = train.TrainType.Name;
			}
			return trainsDto;
		}

		public TrainTypeDto GetTrainType(int id) {
			return _trainTypeRepository.Get(id).MapTo<TrainTypeDto>();
		}

		public ICollection<TrainTypeDto> GetTrainTypes() {
			return _trainTypeRepository.GetAll().MapTo<ICollection<TrainTypeDto>>();
		}

		public void UpdateTrain(TrainDto trainDto) {
			var train = trainDto.MapTo<Train>();
			_trainRepository.Update(train);
		}

		public void UpdateTrainType(TrainTypeDto TrainTypeDto) {
			var TrainType = new TrainType {
				Id = TrainTypeDto.Id,
				Name = TrainTypeDto.Name
			};
			_trainTypeRepository.Update(TrainType);
		}
	}
}
