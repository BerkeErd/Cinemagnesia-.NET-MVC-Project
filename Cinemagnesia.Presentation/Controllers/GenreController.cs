using Application.Interfaces.AppInterfaces;
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

        public IActionResult Index()
        {
            var data = _genreService.GetAllGenres();

            return View(data);
        }
        [HttpPost]
        public IActionResult CreateGenre(GenreViewModel genreViewModel)
        {
            if (ModelState.IsValid)
            {
                Genre genre = new Genre
                {
                    Name = genreViewModel.Name
                };
                _genreService.AddGenre(genre);
                return RedirectToAction("Index");
            }
            else
            {
                return Ok("Ekleme işlemi başarısız ☺");
            }
        }
        [HttpGet]
        public IActionResult GetById(string id)
        {
            var genre = _genreService.GetById(id);
            return Ok(genre);
        }
    }
}
