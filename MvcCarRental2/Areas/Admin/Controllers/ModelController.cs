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
    public class ModelController(AppDbContext dbContext) : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var models = await dbContext.Models
            .Include(m => m.Brand)      
            .Include(m => m.CarType)    
            .ToListAsync();

            return View(models);



        }

        public async Task<IActionResult> Create()
        {
            await PopulateViewBags();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ModelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var item = new Model
                {
                    Name = model.Name,
                    BrandId = model.BrandId, // Bu eksikti
                    CarTypeId = model.CarTypeId, // Bu eksikti
                    EngineType = model.EngineType,
                };
                dbContext.Add(item);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            // ModelState geçersizse ViewBag'leri tekrar doldur
            await PopulateViewBags();
            return View(model);
        }

        private async Task PopulateViewBags()
        {
            ViewBag.Brands = new SelectList(await dbContext.Brands.ToListAsync(), "Id", "Name");
            ViewBag.CarTypes = new SelectList(await dbContext.CarTypes.ToListAsync(), "Id", "Name");
            ViewBag.EngineTypes = Enum.GetValues(typeof(EngineTypes)).Cast<EngineTypes>().ToList();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var model=await dbContext.Models.FindAsync(Id);
            var viewModel = new ModelViewModel
            {
                Id = model.Id,
                Name = model.Name,
                BrandId = model.BrandId,
                CarTypeId = model.CarTypeId,
                EngineType = model.EngineType,
            };
            ViewBag.Brands = new SelectList(await dbContext.Brands.ToListAsync(), "Id", "Name");
            await PopulateViewBags();
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ModelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var item = await dbContext.Models.FindAsync(model.Id);
                item.Name = model.Name;
                item.BrandId = model.BrandId; 
                item.CarTypeId = model.CarTypeId; 
                item.EngineType = model.EngineType;
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Brands = new SelectList(await dbContext.Brands.ToListAsync(), "Id", "Name");
            await PopulateViewBags();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Model viewModel)
        {
            var model = await dbContext.Models.FindAsync(viewModel.Id);
            if (model is not null)
            {
                dbContext.Models.Remove(model);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}