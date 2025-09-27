using Microsoft.EntityFrameworkCore;
using MvcCarRental2.Web.Domain;

namespace MvcCarRental2.Web.Data
{
    public class AppDbContext(DbContextOptions options): DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<Rent> Rent { get; set; }
       
    }
}
