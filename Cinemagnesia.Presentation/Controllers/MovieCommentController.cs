using Application.Interfaces.AppInterfaces;
using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Cinemagnesia.Presentation.Controllers
{
    public class MovieCommentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMovieCommentService _movieCommentService;

        public MovieCommentController(IMapper mapper, IMovieCommentService movieCommentService)
        {
            _mapper = mapper;
            _movieCommentService = movieCommentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public int GetNumOfMovieComments()
        {
            return _movieCommentService.GetNumOfMovieComments();
        }
    }
}
