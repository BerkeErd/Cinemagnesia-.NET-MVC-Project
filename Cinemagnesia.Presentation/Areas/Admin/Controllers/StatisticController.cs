using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using Application.Services;
using AutoMapper;
using Cinemagnesia.Presentation.Areas.Admin.Models;
using Cinemagnesia.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ASPNET_Core_2_1.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        private readonly IGenreService _genreService;
        private readonly IMovieService _movieService;

        public StatisticController(IMapper mapper, UserService userService, IGenreService genreService, IMovieService movieService)
        {
            _mapper = mapper;
            _userService = userService;
            _genreService = genreService;
            _movieService = movieService;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public int GetNumOfUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet]
        public List<GenreStatisticViewModel> GetStatisticOfGenre()
        {
            var GenreWithCount = _genreService.GetGenresWithMovies();
            var MovieCount = _movieService.GetNumOfActiveMovies();

            List<GenreStatisticViewModel> statistic = new List<GenreStatisticViewModel>();
            foreach (var genre in GenreWithCount)
            {
                GenreStatisticViewModel genreStatisticViewModel = new GenreStatisticViewModel();
                genreStatisticViewModel.Name = genre.Name;
                genreStatisticViewModel.Count = genre.MovieCount;
                statistic.Add(genreStatisticViewModel);
            }
            return statistic;
        }

        [HttpGet]
        public async Task<List<GetMovieLanguagesViewModel>> GetLanguageStatistics()
        {
            List<LanguageStatisticDto> languageWithCount = await _movieService.GetLanguageStatistics();
            var movieCount = _movieService.GetNumOfActiveMovies();

            List<GetMovieLanguagesViewModel> statistic = new List<GetMovieLanguagesViewModel>();
            foreach (var language in languageWithCount)
            {
                GetMovieLanguagesViewModel languageStatisticsViewModel = new GetMovieLanguagesViewModel();
                languageStatisticsViewModel.Name = language.Name;
                languageStatisticsViewModel.Count = language.MovieCount;
                statistic.Add(languageStatisticsViewModel);
            }
            return statistic;
        }
    }
}