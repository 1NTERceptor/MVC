using CarWorkshop.Domain.Entities;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Queries
{
    public class GetCarWorkshopByEncodednameQuery : IRequest<CarWorkshopUnit>
    {
        public string EncodedName { get; set; }
    }
}
