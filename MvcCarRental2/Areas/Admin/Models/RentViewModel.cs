namespace MvcCarRental2.Web.Areas.Admin.Models
{
    public class RentViewModel
    {
        
        public Guid CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
