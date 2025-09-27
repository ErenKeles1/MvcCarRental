using MvcCarRental2.Web.Domain;

namespace MvcCarRental2.Web.Areas.Admin.Models
{
    public class CarViewModel
    {
        public Guid Id { get; set; }
        public string? PlateNumber { get; set; }
        public Guid ModelId { get; set; }
        public int? Year { get; set; }
        public decimal Price { get; set; }
        public TransmissionTypes TransmissionType { get; set; }
        public string ImageAdress { get; set; }
    }
}
