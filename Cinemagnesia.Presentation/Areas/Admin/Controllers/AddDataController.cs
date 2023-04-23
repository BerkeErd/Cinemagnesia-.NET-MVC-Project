using Cinemagnesia.Presentation.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinemagnesia.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddDataController : Controller
    {
        public IActionResult Index()
        {
            List<GenreViewModel> genreViewModels = new List<GenreViewModel>
            {
                new GenreViewModel
                {
                    Id = "0C161892-979C-4A15-8876-E4FE6C044D41",
                    Name = "Korku"
                },
                new GenreViewModel
                {
                    Id = "0C161892-979C-4A15-8876-E4FE6C044D42",
                    Name = "Drama"
                },
            };
            ViewBag.GenreViewModels = genreViewModels;
            return View();
        }

        public IActionResult AddGenre(AddGenreViewModel addGenreViewModel)
        {
            if (ModelState.IsValid)
            {
                return Ok(addGenreViewModel);
            }
            return BadRequest("Eklenmedi");
        }
    }
}
