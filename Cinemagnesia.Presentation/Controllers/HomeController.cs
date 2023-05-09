using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Cinemagnesia.Presentation.Areas.Admin.Models;
using Cinemagnesia.Presentation.Models;
using Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Packaging;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cinemagnesia.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger,IMovieService movieService,IGenreService genreService,IMapper mapper)
        {
            _mapper = mapper;
            _genreService = genreService;
            _movieService = movieService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var genresDto = _genreService.GetAllGenres();
            var genres = _mapper.Map<List<GenreViewModel>>(genresDto);
            return View(genres);
        }
        [HttpGet]
        public IActionResult GetHomeMovies([FromQuery(Name ="genres")] string genresString)
        {
         
            var movies = _movieService.GetAllHomeMovies();
            if (!string.IsNullOrWhiteSpace(genresString))
            {
                var genres = genresString.Split(',');
                movies = movies.Where(m => m.Genres.Any(g => genres.Contains(g.Name.ToLower()))).ToList();
                return Ok(movies);
            }
            else
            {
                return Ok(movies);
            }
                
         
          


        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult Assistant()
        {
            var viewModel = new AssistantViewModel
            {
                ApiResponse = string.Empty
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Assistant(string message)
        {

            message = "Sen Cinemagnesia adlı film sitesinde bir yardımcı elemansın. Bana vereceğin cevapları yazarken bu role uygun bir şekilde yaz. Bana yardımcı olmaya çalış fakat yapabileceğinden daha fazla bir istekde bulunursa " +
                "Admin@cinemagnesia.com'a email atarak admin'e ulaşmam gerektiğini söyleyebilirsin. Şimdi sana siteyi tanıtıp sonra da mesajımı söyleyeceğim. Cinemagnesia'da Üyeler - Yayımlanan filmlere yorum yapabilir, " +
                "1-5 arasında puan verebilir. Yorum yaptığı ve oy verdiği filmler profilinde listelenebilir.İzlediği veya izlemek istediği filmleri işaretleyebilir.Üyeler kayıt gerçekleştirden sonra isterse " +
                "Yapımcı olmak için sisteme istek yollayabilir. Üyeler isterse Yapımcı olmak için başvuru yapabilir ve yapımcılığa yükseltilebilirler. Yapımcılar Üyeler'in sahip olduğu tüm yetkinliklere sahiptir." +
                " Harici olarak sisteme film ekleme isteği gönderebilir Şimdi Sana Sorumu Söylüyorum :  : " + message;


            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://openai80.p.rapidapi.com/chat/completions"),
                Headers =
        {
            { "X-RapidAPI-Key", "fdcfdb9d98mshf0a8ac4934e1a88p138684jsn90c0b90433f3" },
            { "X-RapidAPI-Host", "openai80.p.rapidapi.com" },
        },
                Content = new StringContent("{\r\n    \"model\": \"gpt-3.5-turbo\",\r\n    \"messages\": [\r\n        {\r\n            \"role\": \"user\",\r\n            \"content\": \"" + message + "\"\r\n        }\r\n    ]\r\n}")
                {
                    Headers =
            {
                ContentType = new MediaTypeHeaderValue("application/json")
            }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseJson = JObject.Parse(responseBody);
                var replyMessage = responseJson["choices"][0]["message"]["content"].ToString();
                ViewBag.Message = replyMessage;
            }

            return View();
        }


    }
}