using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Persistance
{
    public class CarWorkshopDbContext : DbContext
    {
        public CarWorkshopDbContext(DbContextOptions<CarWorkshopDbContext> options)
            : base(options)
        {

        }

        public DbSet<Domain.Entities.CarWorkshopUnit> CarWorkshops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.CarWorkshopUnit>()
                .OwnsOne(e => e.ContactDetails);
        }
    }
}
