using Application.Dtos;
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
        MovieCommentDto AddMovieComment(SendMovieCommentDto sendMovieComment);
        void DeleteMovieComment(string id);
        void UpdateMovieComment(string movieCommentId, MovieComment movieComment);
        int GetNumOfMovieComments();
        List<CommentStatsDto> GetCommentStats();
    }
}
