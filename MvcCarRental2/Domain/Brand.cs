using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCarRental2.Web.Domain
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string ImageAdress { get; set; }
        public ICollection<Model> Models { get; set; } = new List<Model>();
        
    }
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder
                 .HasMany(p => p.Models)
                 .WithOne(p => p.Brand)
                 .HasForeignKey(p => p.BrandId)
                 .OnDelete(DeleteBehavior.Restrict);
            builder
                .Property(p => p.Name)
                .IsRequired();
        }
    }


}
