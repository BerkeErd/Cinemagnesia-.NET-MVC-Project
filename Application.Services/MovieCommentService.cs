using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MovieCommentService : IMovieCommentService
    {
        private readonly IMovieCommentRepository _movieCommentRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public MovieCommentService(IMovieCommentRepository movieCommentRepository, IMapper mapper)
        {
            _movieCommentRepository = movieCommentRepository;
            _mapper = mapper;
        }
        public MovieComment GetMovieCommentById(string id)
        {
            return _movieCommentRepository.GetByIdAsync(id).Result;
        }
        public MovieCommentDto AddMovieComment(SendMovieCommentDto sendMovieComment)
        {
            var movieComment = _mapper.Map<MovieComment>(sendMovieComment);

            var response = _movieCommentRepository.CreateAsync(movieComment).Result;

            MovieCommentDto movieCommentDto = _mapper.Map<MovieCommentDto>(response);      
            return movieCommentDto;
        }
        public void DeleteMovieComment(string id)
        {
            _movieCommentRepository.DeleteAsync(id).Wait();
        }

        public void UpdateMovieComment(string movieCommentId, MovieComment movieComment)
        {
            _movieCommentRepository.Update(movieCommentId, movieComment);
        }

        public int GetNumOfMovieComments()
        {
            return _movieCommentRepository.GetNumOfMovieComments();
        }

        public List<CommentStatsDto> GetCommentStats()
        {
            var allComments = _movieCommentRepository.GetAllComments();

            var commentStats = allComments
                .GroupBy(c => new { c.Movie.Title, GenreNames = c.Movie.Genres.Select(g => g.Name).ToList() })
                .Select(g => new CommentStatsDto
                {
                    MovieName = g.Key.Title,
                    GenreNames = g.Key.GenreNames,
                    CommentCount = g.Count()
                })
                .ToList();

            return commentStats;
        }
    }
}
