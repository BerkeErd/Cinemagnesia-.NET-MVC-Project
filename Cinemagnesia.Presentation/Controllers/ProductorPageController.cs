using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Cinemagnesia.Presentation.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinemagnesia.Presentation.Controllers
{
    public class ProductorPageController : Controller
    {
        private IGenreService _genreService;
        private IMapper _mapper;

        public ProductorPageController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMovieView()
        {
            List<GenreDto> genredtos = _genreService.GetAllGenres();
            List<GenreViewModel> genreViewModels = _mapper.Map<List<GenreViewModel>>(genredtos)  ;

            return View(genreViewModels);
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
