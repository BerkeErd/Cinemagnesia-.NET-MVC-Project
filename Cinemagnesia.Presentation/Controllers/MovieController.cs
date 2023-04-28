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
            return Ok(directors);

            List<string> genreNames = JsonConvert.DeserializeObject<List<string>>(genres);
            List<Genre> genresList = new List<Genre>();

            foreach (string genreName in genreNames)
            {
                Genre genre = new Genre()
                {
                    Name = genreName
                };

                genresList.Add(genre);
            }

            List<string> castmemberNames = JsonConvert.DeserializeObject<List<string>>(castMembers);
            List<CastMember> castmemberList = new List<CastMember>();

            foreach (string castMemberName in castmemberNames)
            {
                CastMember castMember = new CastMember()
                {
                    Name = castMemberName
                };

                castmemberList.Add(castMember);
            }
            
            List<string> directorNames = JsonConvert.DeserializeObject<List<string>>(directors);
            List<Director> directorsList = new List<Director>();

            foreach (string directorName in directorNames)
            {
                Director director = new Director()
                {
                    Name = directorName
                };

                directorsList.Add(director);
            }

            AddMovieDto addmovieDto = new AddMovieDto()
            {
                Title = title,
                Description = description,
                CompanyId = companyId,
                ReleaseDate = DateTime.Parse(releaseDate),
                ImdbRating = float.Parse(imdbRating),
                TrailerUrl = trailerUrl,
                MovieMinutes = Convert.ToInt32(movieMinute),
                Language = language,
                Directors = directorsList,
                Genres = genresList,
                CastMembers = castmemberList
            };

            return Ok(addmovieDto);

        }



        public IActionResult MovieDetail()
        {
            return View();
        }

    }
}


