using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Reflection.PortableExecutable;

namespace Cinemagnesia.Presentation.Controllers
{
    public class MovieController : Controller
    {
        private readonly HttpClient _httpClient;

        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("rapidapi");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
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
    }
}


