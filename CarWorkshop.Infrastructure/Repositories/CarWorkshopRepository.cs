using AutoMapper;
using CarWorkshop.Application.Commands;
using CarWorkshop.Application.Models;
using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopDbContext _dbContext;
        private readonly IMapper _mapper;

        public CarWorkshopRepository(CarWorkshopDbContext dbContext, IMapper mapper) 
        { 
            _dbContext = dbContext;
            _mapper = mapper;
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

        public async Task<IEnumerable<CarWorkshopInputModel>> GetAll()
        {
            var carWorkshops = await _dbContext.CarWorkshops.ToListAsync();

            return _mapper.Map<IEnumerable<CarWorkshopInputModel>>(carWorkshops);
        }

        public async Task<CarWorkshopUnit> GetByName(string name)
        {
            return await _dbContext.CarWorkshops.SingleAsync(cw => cw.Name == name);
        }

        public async Task<CarWorkshopUnit> GetByEncodedname(string encodedName)
        {
            return await _dbContext.CarWorkshops.SingleAsync(cw => cw.EncodedName == encodedName);
        }

        public async Task<int> Edit(CarWorkshopUnit carWorkshop)
        {
            _dbContext.CarWorkshops.Update(carWorkshop);
            await _dbContext.SaveChangesAsync();
            return _dbContext.CarWorkshops.Where(cw => cw.Name == carWorkshop.Name).First().Id;
        }
    }
}
