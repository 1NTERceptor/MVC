using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CarWorkshop.Infrastructure.Persistance
{
    public class CarWorkshopDbContextFactory : IDesignTimeDbContextFactory<CarWorkshopDbContext>
    {
        public CarWorkshopDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "CarWorkshop.MVC"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CarWorkshopDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new CarWorkshopDbContext(optionsBuilder.Options);
        }
    }
}
