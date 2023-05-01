using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Cinemagnesia.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductorDataRequestController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public ProductorDataRequestController(IMovieService movieService, IMapper mapper)
        {
            _mapper = mapper;
            _movieService = movieService;   
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = _movieService.GetAllMovies();
           // var movieDtos = _mapper.Map<List<MovieDto>>(movies); BUGLI
            return Ok(movies);
        }
    }
}
