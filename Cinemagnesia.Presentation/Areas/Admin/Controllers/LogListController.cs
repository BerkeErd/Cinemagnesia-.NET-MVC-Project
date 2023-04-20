using Microsoft.AspNetCore.Mvc;

namespace Cinemagnesia.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LogListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
