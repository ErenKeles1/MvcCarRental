using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MvcCarRental2.Web.Domain
{
    public class Rent
    {
        
        
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Car? Car { get; set; }
        
    }

    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            // StartDate ve EndDate'in UTC olarak kaydedilmesi
            builder.Property(r => r.StartDate)
                .HasConversion(
                    v => v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
                .IsRequired();

            builder.Property(r => r.EndDate)
                .HasConversion(
                    v => v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
                .IsRequired();

            builder
                 .HasOne(r => r.Car)
                 .WithMany(c => c.Rents)
                 .HasForeignKey(r => r.CarId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
