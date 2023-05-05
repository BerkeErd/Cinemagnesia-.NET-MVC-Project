using Application.Dtos;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IQueryable<Movie> GetAllWaitingMovies();
        IQueryable<Movie> GetAllHomeMovies();
        IQueryable<Movie> GetAllMovieswithLikes();
        void AddToRatedUsersList(string userId, string movieId);
        int GetNumOfActiveMovies();
        void UpdateAverageScore(string movieId, float rating);
        Movie GetMovieById(string id);
        List<MovieRankingDto> GetMovieRankings();
        Task<List<LanguageStatisticDto>> GetLanguageStatistics();
        Task<string> GetMostRatedMovie();
    }
}
