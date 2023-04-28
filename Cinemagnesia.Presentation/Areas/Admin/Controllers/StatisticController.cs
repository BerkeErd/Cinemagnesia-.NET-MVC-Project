using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Cinemagnesia.Presentation.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASPNET_Core_2_1.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        public StatisticController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //var genres = _genreService.GetAllGenres();
            //List<GenreViewModel> genreList = _mapper.Map<List<GenreDto>, List<GenreViewModel>>(genres);

            //string serializeData = JsonConvert.SerializeObject(genreList);
            //ViewBag.genreList = genreList;
            return View();
        }
        [HttpGet]
        public IActionResult ListGenres()
        {
            IQueryable<GenreDto> genreDtos = _genreService.GetAllGenres().AsQueryable();
            IQueryable<GenreViewModel> genreViewModels = _mapper.ProjectTo<GenreViewModel>(genreDtos);

            return Ok(genreViewModels);
        }
        public IActionResult Dashboard_2()
        {
            return View();
        }

        public IActionResult Dashboard_3()
        {
            return View();
        }

        public IActionResult Dashboard_4()
        {
            return View();
        }

        public IActionResult Dashboard_4_1()
        {
            return View();
        }

        public IActionResult Dashboard_5()
        {
            return View();
        }
    }
}