using AutoMapper;
using CarWorkshop.Application.Models;
using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;

namespace CarWorkshop.Application.Services
{
    public class CarWorkshopService : ICarWorkshopService
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;
        public CarWorkshopService(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }

        public async Task<int> Creat(CarWorkshopInputModel carWorkshopModel)
        {
            var carWorkshop = _mapper.Map<CarWorkshopUnit>(carWorkshopModel);

            carWorkshop.EncodeName();

            return await _carWorkshopRepository.Create(carWorkshop);
        }

        public async Task<CarWorkshopUnit> Get(int id)
        {
            return await _carWorkshopRepository.Get(id);
        }
    }
}
