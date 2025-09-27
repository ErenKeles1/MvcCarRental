using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCarRental2.Web.Areas.Admin.Models;
using MvcCarRental2.Web.Data;
using MvcCarRental2.Web.Domain;
namespace MvcCarRental2.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CarController(AppDbContext dbContext) : Controller
    {

        public async Task<IActionResult> Index() 
        {
            var cars = await dbContext.Cars
                .Include(c => c.Model) 
                .ToListAsync();

            return View(cars); 
        }
        public IActionResult Create()
        {
            ViewBag.Models = new SelectList(dbContext.Models, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarViewModel model)
        {
            if (ModelState.IsValid)
            {
                var item = new Car
                {
                    PlateNumber = model.PlateNumber,
                    Year = model.Year,
                    Price = model.Price,
                    TransmissionType = model.TransmissionType,
                    ImageAdress = model.ImageAdress,
                    ModelId=model.ModelId,
                };
                dbContext.Add(item);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Models = new SelectList(await dbContext.Models.ToListAsync(), "Id", "Name");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var car = await dbContext.Cars.FindAsync(Id);
            var viewModel = new CarViewModel
            {
                Id = car.Id,
                PlateNumber=car.PlateNumber,
                ModelId=car.ModelId ?? Guid.Empty,
                Year=car.Year,
                Price=car.Price,
                TransmissionType=car.TransmissionType,
                ImageAdress=car.ImageAdress,
            };
            ViewBag.Models = new SelectList(await dbContext.Models.ToListAsync(), "Id", "Name", car.ModelId);
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CarViewModel model)
        {

            var car= await dbContext.Cars.FindAsync(model.Id);
            if (car is not null)
            {
                car.PlateNumber = model.PlateNumber;
                car.ImageAdress = model.ImageAdress;
                car.ModelId = model.ModelId;
                car.Year = model.Year;
                car.Price = model.Price;
                car.TransmissionType = model.TransmissionType;


                await dbContext.SaveChangesAsync();

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Car viewModel)
        {
            var car=await dbContext.Cars.FindAsync(viewModel.Id);
            if (car is not null)
            {
                dbContext.Cars.Remove(car);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }

}
