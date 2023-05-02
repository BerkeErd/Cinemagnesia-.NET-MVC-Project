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
using Microsoft.AspNetCore.Authorization;

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
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
          

        }

        [Authorize]
        public IActionResult MoviePage()
        {
            var id = Request.Query["id"].ToString();
            MovieDto movieDto = _movieService.GetMovieDtoById(id);
            
            MovieDetailViewModel movieDetailViewModel = _mapper.Map<MovieDetailViewModel>(movieDto);

            bool isRatedBefore = false;
            bool isLikedBefore = false;
            int Rate = 0;

            if(User.Identity.IsAuthenticated)
            {
                Rate = _ratingService.GetRateoftheUser(_userManager.GetUserAsync(User).Result.Id, movieDetailViewModel.Id);
             
                if(Rate > 0) 
                {
                    isRatedBefore = true;
                }
                   
            }

           
                var activeMovies = _movieService.GetAllMovieswithLikes();

                if (activeMovies != null)
                {
                    foreach (var movie in activeMovies) // Film daha önce oylanmış mı?
                    {

                        if (movie.UserLikes == movieDetailViewModel.UserLikes)
                        {
                            isLikedBefore = true;
                            break;
                        }
                    }
                }

            

            ViewData["isRatedBefore"] = isRatedBefore;
            ViewData["isLikedBefore"] = isLikedBefore;
            ViewData["Rate"] = Rate;




            return View(movieDetailViewModel);
        }

        public int GetNumOfMovies()
        {
            return _movieService.GetNumOfMovies();
        }

        [HttpGet]
        public IActionResult GetHomeMovies()
        {
            var data = _movieService.GetAllHomeMovies();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddRating(Rating rating)
        {
            _ratingService.AddRating(rating);
            _movieService.AddToRatedUsersList(rating.ApplicationUserId, rating.MovieId);
            return Ok("oldu herhalde");
        }


      


    }
}


