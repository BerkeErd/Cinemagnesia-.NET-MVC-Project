using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using Microsoft.Extensions.Logging;
using Cinemagnesia.Presentation.Models;
using Domain.Entities.Concrete;
using Application.Dtos;
using System.Data.SqlTypes;
using Newtonsoft.Json;
using AutoMapper;
using Infrastructure.DataAccess.Migrations;
using Application.Interfaces.AppInterfaces;

namespace Cinemagnesia.Presentation.Controllers
{
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IMovieService _movieService;
        public MovieController(IHttpClientFactory httpClientFactory, IMapper mapper, IWebHostEnvironment env,IMovieService movieService)
        {
            _movieService = movieService;
            _mapper = mapper;
            _httpClient = httpClientFactory.CreateClient("rapidapi");
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("");

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("/titles?page=2", UriKind.Relative)
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return Ok(body);
            }
        }

        [HttpPost]
        public IActionResult AddMovie(IFormFile poster, string companyId, string title, string description, string releaseDate, string imdbRating, string trailerUrl, string directors, string genres, string castMembers, string movieMinute, string language)
        {
            List<AddGenreToMovieViewModel> genreNames = JsonConvert.DeserializeObject<List<AddGenreToMovieViewModel>>(genres);
            List<AddCastMemberViewModel> castmemberNames = JsonConvert.DeserializeObject<List<AddCastMemberViewModel>>(castMembers);
            List<AddDirectorViewModel> directorNames = JsonConvert.DeserializeObject<List<AddDirectorViewModel>>(directors);

            string fileName = $"{Guid.NewGuid().ToString()}_{poster.FileName}";
            string filePath = Path.Combine(_env.WebRootPath, "images", "Cinemagnesia", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                poster.CopyToAsync(stream);
            }

            AddMovieViewModel addMovieViewModel = new AddMovieViewModel()
            {
                Title = title,
                Description = description,
                CompanyId = companyId,
                ReleaseDate = DateTime.Parse(releaseDate),
                ImdbRating = float.Parse(imdbRating),
                TrailerUrl = trailerUrl,
                MovieMinute = Convert.ToInt32(movieMinute),
                Language = language,
                Directors = directorNames,
                Genres = genreNames,
                CastMembers = castmemberNames,
                PosterPath = fileName
                
            };

            AddMovieDto addMovieDto = _mapper.Map<AddMovieDto>(addMovieViewModel);
            _movieService.AddMovie(addMovieDto);
            return Ok(addMovieDto);

        }



        public IActionResult MoviePage()
        {
            return View();
        }

    }
}


