using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCarRental2.Web.Areas.Admin.Models;
using MvcCarRental2.Web.Data;
using MvcCarRental2.Web.Domain;
using System.Threading.Tasks;

namespace MvcCarRental2.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BrandController(AppDbContext dbContext) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var brands = await dbContext.Brands.ToListAsync();
            return View(brands);
            
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BrandViewModel model)
        {
            var item = new Brand
            {
                Name = model.Name,
                ImageAdress = model.ImageAdress,
            };
            dbContext.Add(item);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var brand=await dbContext.Brands.FindAsync(Id);
            var viewModel = new BrandViewModel
            {
                Id = brand.Id,
                Name = brand.Name,
                ImageAdress = brand.ImageAdress
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BrandViewModel model)
        {
           var brand= await dbContext.Brands.FindAsync(model.Id);
            if(brand is not null)
            {
                brand.Name = model.Name;
                brand.ImageAdress = model.ImageAdress;

                await dbContext.SaveChangesAsync();

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Brand viewModel)
        {
            var brand = await dbContext.Brands.FindAsync(viewModel.Id);
            if (brand is not null)
            {
                dbContext.Brands.Remove(brand);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}
