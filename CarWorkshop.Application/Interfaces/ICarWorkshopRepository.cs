using CarWorkshop.Application.Models;
using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopRepository
    {
        Task<int> Create(CarWorkshopUnit carWorkshop);
        Task<CarWorkshopUnit> Get(int id);
        Task<CarWorkshopUnit> GetByName(string name);
        Task<CarWorkshopUnit> GetByEncodedname(string encodedname);
        Task<IEnumerable<CarWorkshopInputModel>> GetAll();

        Task<int> Edit(CarWorkshopUnit carWorkshop);
        Task<CarWorkshopUnit> GetById(int id);
        Task Commit();
    }
}
