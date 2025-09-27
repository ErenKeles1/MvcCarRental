using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCarRental2.Web.Data;

namespace MvcCarRental2.Web.Controllers
{
    public class CarsController(AppDbContext dbContext) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var cars =await dbContext.Cars
                    .Include(c => c.Model)
                    .ThenInclude(m => m.Brand)
                    .ToListAsync();
            return View(cars);
        }

        
    }
}
