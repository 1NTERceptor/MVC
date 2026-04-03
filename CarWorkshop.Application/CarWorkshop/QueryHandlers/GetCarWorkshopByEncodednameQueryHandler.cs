using CarWorkshop.Application.CarWorkshop.Queries;
using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.QueryHandlers
{
    public class GetCarWorkshopByEncodednameQueryHandler : IRequestHandler<GetCarWorkshopByEncodednameQuery, CarWorkshopUnit>
    {
        public ICarWorkshopRepository _carWorkshopRepository;
        public GetCarWorkshopByEncodednameQueryHandler(ICarWorkshopRepository carWorkshopRepository) 
        { 
            _carWorkshopRepository = carWorkshopRepository;
        }

        public async Task<CarWorkshopUnit> Handle(GetCarWorkshopByEncodednameQuery request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRepository.GetByEncodedname(request.EncodedName);

            return carWorkshop;
        }
    }
}
