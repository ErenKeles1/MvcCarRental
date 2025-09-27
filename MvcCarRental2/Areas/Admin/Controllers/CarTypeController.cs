using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCarRental2.Web.Areas.Admin.Models;
using MvcCarRental2.Web.Data;
using MvcCarRental2.Web.Domain;

namespace MvcCarRental2.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CarTypeController(AppDbContext dbContext) : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var carTypes = await dbContext.CarTypes.ToListAsync();
            return View(carTypes);
           
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(CarTypeViewModel model)
        {
            var item = new CarType
            {
                Name = model.Name,
            };
            dbContext.Add(item);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var carType = await dbContext.CarTypes.FindAsync(Id);
            var viewModel = new CarTypeViewModel
            {
                Id = carType.Id,
                Name = carType.Name,
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CarTypeViewModel model)
        {
            var carType = await dbContext.CarTypes.FindAsync(model.Id);
            if(carType is not null)
            {
                carType.Name = model.Name;
                await dbContext.SaveChangesAsync(); 
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var carType = await dbContext.CarTypes.FindAsync(Id);
            if(carType is not null)
            {
                dbContext.Remove(carType);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}
