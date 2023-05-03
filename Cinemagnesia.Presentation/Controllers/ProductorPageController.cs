using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Cinemagnesia.Presentation.Areas.Admin.Models;
using Cinemagnesia.Presentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cinemagnesia.Presentation.Controllers
{
    public class ProductorPageController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductorPageController(IGenreService genreService, IMapper mapper, IMovieService movieService, UserManager<ApplicationUser> userManager)
        {
            _genreService = genreService;
            _mapper = mapper;
            _movieService = movieService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMovieView()
        {
            List<GenreDto> genredtos = _genreService.GetAllGenres();
            List<GenreViewModel> genreViewModels = _mapper.Map<List<GenreViewModel>>(genredtos);

            return View(genreViewModels);
        }

        public IActionResult ListMovieView()
        {
                string userId = _userManager.GetUserId(User);
                var user = _userManager.FindByIdAsync(userId).Result;
                string companyId = user.CompanyId;
            // Get the movies associated with the specified company
            List<MovieDto> movieDtos = _movieService.GetMoviesByCompanyId(companyId,true);

            // Map the movie DTOs to movie view models
            List<MovieViewModel> movieViewModels = _mapper.Map<List<MovieViewModel>>(movieDtos);

            return View(movieViewModels);
            
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
