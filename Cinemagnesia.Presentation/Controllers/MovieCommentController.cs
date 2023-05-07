﻿using Application.Dtos;
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
                SendMovieCommentDto sendMovieCommentDto = _mapper.Map<SendMovieCommentDto>(sendCommentViewModel);
                sendMovieCommentDto.CreatedAt = DateTime.Now;
                MovieCommentDto response = _movieCommentService.AddMovieComment(sendMovieCommentDto);
                
;               return Ok(response);
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

        [HttpGet]
        public IActionResult GetCommentStats()
        {
            var stats = _movieCommentService.GetCommentStats();
            var result = stats
                .GroupBy(s => s.GenreName)
                .Select(g => new
                {
                    genreName = g.Key,
                    data = g.GroupBy(s => s.MovieName)
                        .Select(movieGroup => new
                        {
                            movieName = movieGroup.FirstOrDefault().MovieName,
                            commentcount = movieGroup.Sum(s => s.CommentCount)
                        })
                });

            return Ok(result);
        }
    }
}
