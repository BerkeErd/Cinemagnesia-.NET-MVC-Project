using Application.Interfaces.AppInterfaces;
using Cinemagnesia.Presentation.Areas.Admin.Models;
using Cinemagnesia.Presentation.Models;
using Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cinemagnesia.Presentation.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _genreService.GetAllGenres();

            return View(data);
        }




    }
}
