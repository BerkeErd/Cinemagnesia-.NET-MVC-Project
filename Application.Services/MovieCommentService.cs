using Application.Interfaces.AppInterfaces;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
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
        public MovieCommentService(IMovieCommentRepository movieCommentRepository)
        {
            _movieCommentRepository = movieCommentRepository;
        }
        public MovieComment GetMovieCommentById(string id)
        {
            return _movieCommentRepository.GetByIdAsync(id).Result;
        }
        public void AddMovieComment(MovieComment movieComment)
        {
            _movieCommentRepository.CreateAsync(movieComment).Wait();
        }
        public void DeleteMovieComment(string id)
        {
            _movieCommentRepository.DeleteAsync(id).Wait();
        }

        public void UpdateMovieComment(string movieCommentId, MovieComment movieComment)
        {
            _movieCommentRepository.UpdateAsync(movieCommentId, movieComment).Wait();
        }
    }
}
