using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopRepository
    {
        Task<int> Create(CarWorkshopUnit carWorkshop);
        Task<CarWorkshopUnit> Get(int id);
    }
}
