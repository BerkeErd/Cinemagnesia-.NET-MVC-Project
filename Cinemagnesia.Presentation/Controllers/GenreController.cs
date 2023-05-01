using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _genreService.GetAllGenres();
           
            return View(data);
        }

        [HttpGet]
        public IActionResult ListGenres()
        {
            IQueryable<GenreDto> genreDtos = _genreService.GetAllGenres().AsQueryable();
            IQueryable<GenreViewModel> genreViewModels = _mapper.ProjectTo<GenreViewModel>(genreDtos);

            return Ok(genreViewModels);
        }

        [HttpGet]
        public IActionResult GetGenresWithMovies()
        {
            return Json(_genreService.GetGenresWithMovies());
        }


    }
}
