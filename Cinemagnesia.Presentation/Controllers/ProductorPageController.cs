using Microsoft.AspNetCore.Mvc;

namespace Cinemagnesia.Presentation.Controllers
{
    public class ProductorPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMovieView()
        {
            return View();
        }

        public IActionResult ListMovieView()
        {
            return View();
        }

        public IActionResult _EditMovie()
        {
            return PartialView("_EditMovie");
        }

        public IActionResult PartialView3()
        {
            return PartialView("_PartialView3");
        }
    }
}
