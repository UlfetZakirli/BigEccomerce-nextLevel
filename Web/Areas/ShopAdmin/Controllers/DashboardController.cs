using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.ShopAdmin.Controllers
{
    [Area(nameof(ShopAdmin))]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
