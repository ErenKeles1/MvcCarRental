using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCarRental2.Web.Areas.Admin.Models;
using MvcCarRental2.Web.Data;
using MvcCarRental2.Web.Domain;
using System.Linq;

namespace MvcCarRental2.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RentController(AppDbContext dbContext) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var rents=await dbContext.Rent
                .Include(r=>r.Car)
                .ThenInclude(c=>c.Model)
                .ThenInclude(m=>m.Brand)
                .OrderByDescending(r=>r.StartDate)
                .ToListAsync();
            return View(rents);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RentViewModel model)
        {
            var item = new Rent
            {
                CarId=model.CarId,
                StartDate =model.StartDate,
                EndDate=model.EndDate,
            };
            dbContext.Add(item);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
