using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCarRental2.Web.Domain;


public enum TransmissionTypes
{
    Manual, Automatic, SemiAutomatic
}
public class Car
{
    public Guid Id { get; set; }
    public string PlateNumber { get; set; }
    public int? Year { get; set; }
    public Guid? ModelId { get; set; }
    public decimal Price { get; set; }
    public TransmissionTypes TransmissionType { get; set; }
    public bool IsAvailable { get; set; }
    public Model Model { get; set; }
    public ICollection<Rent> Rents { get; set; } = new List<Rent>();

    
    public string? ImageAdress { get; set; }
}

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasIndex(p => p.PlateNumber)
            .IsUnique();

        builder
            .HasMany(p => p.Rents)
            .WithOne(p => p.Car)
            .HasForeignKey(p => p.CarId)
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .Property(p => p.PlateNumber)
            .HasMaxLength(10)
            .IsRequired();
        
            
       
    }
}