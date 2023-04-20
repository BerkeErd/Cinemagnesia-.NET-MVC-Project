using Microsoft.AspNetCore.Mvc;

namespace Cinemagnesia.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductorRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
