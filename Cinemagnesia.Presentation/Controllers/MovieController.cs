using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using Microsoft.Extensions.Logging;
using Cinemagnesia.Presentation.Models;
using Domain.Entities.Concrete;
using Application.Dtos;
using System.Data.SqlTypes;
using Newtonsoft.Json;

namespace Cinemagnesia.Presentation.Controllers
{
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly HttpClient _httpClient;

        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("rapidapi");
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
                CastMembers = castmemberNames
            };

            return Ok(addMovieViewModel);

        }



        public IActionResult MovieDetail()
        {
            return View();
        }

    }
}


