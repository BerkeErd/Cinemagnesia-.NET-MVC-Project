using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Domain.Entities.Constants;
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
        public IActionResult GetAllWaitingMovies()
        {
            var movies = _movieService.GetAllWaitingMovies();
           // var movieDtos = _mapper.Map<List<MovieDto>>(movies); BUGLI
            return Ok(movies);
        }
        [HttpPost]
        public IActionResult ComfirmMovie(string id)
        {
              _movieService.ComfirmMovie(id);
                return Ok("Başarılı");
            

            
        }
        [HttpPost]
        public IActionResult RejectMovie(string id)
        {
            _movieService.RejectMovie(id);
            return Ok("Başarılı");
            


        }
    }
}