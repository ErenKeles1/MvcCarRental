using Microsoft.AspNetCore.Mvc;
using MvcCarRental2.Web.Data;
using MvcCarRental2.Web.Domain;

namespace MvcCarRental2.Web.Controllers
{
    public class BookingController(AppDbContext dbContext) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Rent(Guid carId)
        {
            var car = await dbContext.Cars.FindAsync(carId);
            if (car == null)
            {
                return NotFound();
            }
            var model = new Rent
            {
               
               
                CarId = car.Id,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1)
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Rent(Rent model)
        {
            if (ModelState.IsValid) 
            {
                var newRent = new Rent
                {

                    CarId = model.CarId,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                };
                dbContext.Rent.Add(newRent);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Completed");
            }
            return View(model);
        }

        public IActionResult Completed()
        {
            return View();
        }
    }
}
