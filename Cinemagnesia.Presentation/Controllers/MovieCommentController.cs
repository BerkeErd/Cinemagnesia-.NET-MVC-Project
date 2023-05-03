using Application.Interfaces.AppInterfaces;
using Application.Services;
using AutoMapper;
using Cinemagnesia.Presentation.Models;
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
        [HttpPost]
        public IActionResult SendComment(SendCommentViewModel sendCommentViewModel)
        {
            if (ModelState.IsValid)
            {
                return Ok(sendCommentViewModel);
            }
            else
            {
                var errors = new List<string>();
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    errors.Add(error.ErrorMessage);
                }
                return BadRequest(errors);
            }
        }
    }
}
