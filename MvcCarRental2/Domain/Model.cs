using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MvcCarRental2.Web.Domain
{
    public enum EngineTypes
    {
        Lpg, Diesel, Gasoline, Electrical
    }
    public class Model
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid BrandId { get; set; }
        public Guid CarTypeId { get; set; }
        public EngineTypes EngineType { get; set; }
        public Brand? Brand { get; set; }
        public CarType? CarType { get; set; }

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }

    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder
                .HasMany(p => p.Cars)
                .WithOne(p => p.Model)
                .HasForeignKey(p => p.ModelId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Property(P => P.Name)
                .IsRequired();
        }
    }
}
