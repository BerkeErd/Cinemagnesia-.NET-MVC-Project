using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Cinemagnesia.Presentation.Areas.Admin.Models;
using Cinemagnesia.Presentation.Models;
using Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Packaging;
using System.Diagnostics;
using System.Linq;

namespace Cinemagnesia.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger,IMovieService movieService,IGenreService genreService,IMapper mapper)
        {
            _mapper = mapper;
            _genreService = genreService;
            _movieService = movieService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var genresDto = _genreService.GetAllGenres();
            var genres = _mapper.Map<List<GenreViewModel>>(genresDto);
            return View(genres);
        }
        [HttpGet]
        public IActionResult GetHomeMovies([FromQuery(Name ="genres")] string genresString)
        {
         
            var movies = _movieService.GetAllHomeMovies();
            if (!string.IsNullOrWhiteSpace(genresString))
            {
                var genres = genresString.Split(',');
                movies = movies.Where(m => m.Genres.Any(g => genres.Contains(g.Name.ToLower()))).ToList();
                return Ok(movies);
            }
            else
            {
                return Ok(movies);
            }
                
         
          


        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}