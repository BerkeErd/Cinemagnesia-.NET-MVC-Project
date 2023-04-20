using Microsoft.AspNetCore.Mvc;

namespace Cinemagnesia.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UIEditController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
