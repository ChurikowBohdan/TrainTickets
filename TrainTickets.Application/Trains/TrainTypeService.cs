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

		public TrainService(
			IRepository<TrainType> trainTypeRepository
		) {
			_trainTypeRepository = trainTypeRepository;
		}

		public void AddTrainType(TrainTypeDto trainTypeDto) {
			var trainType = trainTypeDto.MapTo<TrainType>();
			_trainTypeRepository.Insert(trainType);
		}

		public void DeleteTrainType(int id) {
			_trainTypeRepository.Delete(id);
		}

		public TrainTypeDto GetTrainType(int id) {
			return _trainTypeRepository.Get(id).MapTo<TrainTypeDto>();
		}

		public ICollection<TrainTypeDto> GetTrainTypes() {
			return _trainTypeRepository.GetAll().MapTo<ICollection<TrainTypeDto>>();
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
