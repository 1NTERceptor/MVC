using CarWorkshop.Application.Models;
using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Application.Services
{
    public interface ICarWorkshopService
    {
        Task<int> Creat(CarWorkshopInputModel carWorkshop);
        Task<IEnumerable<CarWorkshopInputModel>> GetAll();
    }
}