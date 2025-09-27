using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MvcCarRental2.Web.Domain
{
    public class CarType
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Model> Models { get; set; } = new List<Model>();

    }
    public class CarTypeConfiguration : IEntityTypeConfiguration<CarType>
    {
        public void Configure(EntityTypeBuilder<CarType> builder)
        {
            builder
                .HasMany(p => p.Models)
                .WithOne(p => p.CarType)
                .HasForeignKey(p => p.CarTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
