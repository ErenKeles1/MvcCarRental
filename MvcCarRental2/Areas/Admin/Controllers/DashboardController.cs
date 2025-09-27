using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCarRental2.Web.Data;

namespace MvcCarRental2.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class DashboardController : Controller
    {
       
        public IActionResult Index()
        {
            ViewBag.UserName = User.Identity.Name;
            return View();
        }
        
    }
}
