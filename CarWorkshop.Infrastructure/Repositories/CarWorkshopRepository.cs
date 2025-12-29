using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopRepository(CarWorkshopDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<int> Create(CarWorkshopUnit carWorkshop)
        {
            _dbContext.CarWorkshops.Add(carWorkshop);
            await _dbContext.SaveChangesAsync();              
            return _dbContext.CarWorkshops.Where(cw => cw.Name == carWorkshop.Name).First().Id;
        }

        public async Task<CarWorkshopUnit> Get(int id)
        {
            return await _dbContext.CarWorkshops.SingleAsync(cw => cw.Id == id);
        }
    }
}
