using Application.Interfaces.AppInterfaces;
using Cinemagnesia.Presentation.Areas.Admin.Models;
using Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Cinemagnesia.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExportFileController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IDirectorService _directorService;
        public ExportFileController(IMovieService movieService, IDirectorService directorService)
        {
            _directorService = directorService;
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            var movies = _movieService.GetAllMovies();
            var directors = _directorService.GetAllDirectors();
            ExportViewModel model = new ExportViewModel();
            ViewBag.model = model;
            //model.movies = movies
            model.directors = directors;
            return View();
        }
    }
}
