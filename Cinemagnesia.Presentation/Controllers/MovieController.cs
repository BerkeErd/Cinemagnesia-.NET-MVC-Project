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
using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Domain.Entities.Constants;
using Microsoft.AspNetCore.Identity;
using Application.Services;

namespace Cinemagnesia.Presentation.Controllers
{
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IMovieService _movieService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRatingService _ratingService;

        public MovieController(IHttpClientFactory httpClientFactory, IMapper mapper, IWebHostEnvironment env, IMovieService movieService, UserManager<ApplicationUser> usermanager, IRatingService ratingService)
        {
            _userManager = usermanager;
            _movieService = movieService;
            _mapper = mapper;
            _httpClient = httpClientFactory.CreateClient("rapidapi");
            _env = env;
            _ratingService = ratingService;
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
            try
            {
                List<AddGenreToMovieViewModel> genreNames = JsonConvert.DeserializeObject<List<AddGenreToMovieViewModel>>(genres);
                List<AddCastMemberViewModel> castmemberNames = JsonConvert.DeserializeObject<List<AddCastMemberViewModel>>(castMembers);
                List<AddDirectorViewModel> directorNames = JsonConvert.DeserializeObject<List<AddDirectorViewModel>>(directors);

                string fileName;

                if (poster == null)
                {
                    fileName = "DefaultMoviePicture.png";
                }
                else
                {
                    fileName = $"{Guid.NewGuid().ToString()}_{poster.FileName}";
                    string filePath = Path.Combine(_env.WebRootPath, "images", "Cinemagnesia", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        poster.CopyToAsync(stream);
                    }
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
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          

        }
        public IActionResult MoviePage()
        {
            var id = Request.Query["id"];
            return Ok(id);

            MovieDetailViewModel movieDetailViewModel = new MovieDetailViewModel()
            {
                Id = "12345",
                CompanyId = "67890",
                CompanyName = "Acme Productions",
                Title = "The Greatest Movie Ever",
                Description = "A thrilling adventure through space and time",
                PosterPath = "/images/Cinemagnesia/DefaultMoviePicture.png",
                ReleaseDate = DateTime.Now,
                ImdbRating = 8.5f,
                CinemagAvgScore = 4.2f,
                Status = ApprovalStatus.Approved,
                TrailerUrl = "dQw4w9WgXcQ",
                Directors = new List<Director>(),
                Genres = new List<Genre>(),
                CastMembers = new List<CastMember>(),
                MovieComments = new List<MovieComment>(),
                UserLikes = new List<ApplicationUser>(),
                MovieMinutes = 120,
                Language = "English",
                CreatedAt = DateTime.Now,
                UpdatedAt = null
            };

            bool isRatedBefore = false;
            int Rate = 0;

            foreach (var Movie in _userManager.GetUserAsync(User).Result.RatedMovies) //Film daha önce oylanmış mı?
            {
                if (Movie.Id == movieDetailViewModel.Id)
                {
                    isRatedBefore = true;
                    Rate = _ratingService.GetRateoftheUser(_userManager.GetUserAsync(User).Result.Id, Movie.Id); // set the Rate to the user's previous rating
                    break;
                }
            }

            ViewData["isRatedBefore"] = isRatedBefore;
            ViewData["Rate"] = Rate;

            return View(movieDetailViewModel);
        }

        public int GetNumOfMovies()
        {
            return _movieService.GetNumOfMovies();
        }

    }
}


