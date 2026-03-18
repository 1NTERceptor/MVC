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

        public async Task<CarWorkshopInputModel> Get(int id)
        {
            var model = await _carWorkshopRepository.Get(id);

            return _mapper.Map<CarWorkshopInputModel>(model);
        }

        public async Task<IEnumerable<CarWorkshopInputModel>> GetAll()
        {
            var carWorkshops = await _carWorkshopRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CarWorkshopInputModel>>(carWorkshops);

            return dtos;
        }

        public async Task<CarWorkshopInputModel> GetByName(string name)
        {
            var carWorkshop = await _carWorkshopRepository.GetByName(name);
            var dto = _mapper.Map<CarWorkshopInputModel>(carWorkshop);

            return dto;
        }

        public async Task<CarWorkshopInputModel> GetByEncodedname(string encodedName)
        {
            var carWorkshop = await _carWorkshopRepository.GetByEncodedname(encodedName);
            var dto = _mapper.Map<CarWorkshopInputModel>(carWorkshop);

            return dto;
        }
    }
}
