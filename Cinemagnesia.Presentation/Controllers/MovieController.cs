using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using Microsoft.Extensions.Logging;

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
        public IActionResult AddMovie(object obj)
        {
            return Ok(obj);
        }


        public IActionResult MovieDetail()
        {
            return View();
        }

    }
}


