using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.AppInterfaces
{
    public interface IMovieCommentService
    {
        MovieComment GetMovieCommentById(string id);
        void AddMovieComment(MovieComment movieComment);
        void DeleteMovieComment(string id);
        void UpdateMovieComment(string movieCommentId, MovieComment movieComment);
        //IEnumerable<MovieComment> GetAllMovieCommentsOfMovie(string movieId);
        //IEnumerable<MovieComment> GetAllMovieCommentsOfMovieByLikeCount(string movieId);
    }
}
