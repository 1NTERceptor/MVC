using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Infrastructure.Persistance
{
    public class CarWorkshopDbContext : IdentityDbContext<IdentityUser>
    {
        public CarWorkshopDbContext(DbContextOptions<CarWorkshopDbContext> options)
            : base(options)
        {

        }

        public DbSet<CarWorkshopUnit> CarWorkshops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.CarWorkshopUnit>()
                .OwnsOne(e => e.ContactDetails);
        }
    }
}
