using Application.Dtos;
using Domain.Entities.Concrete;
using Domain.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.AppInterfaces
{
    public interface IMovieService
    {
        Movie GetMovieById(string id);
        MovieDto GetMovieDtoById(string id);
        List<MovieDto> GetAllWaitingMovies();
        List<HomeMovieDto> GetAllHomeMovies();
        List<MovieDto> GetAllMovieswithLikes();
        List<MovieDto> GetMoviesByCompanyId(string companyId, bool includeMovies = false);
        void AddMovie(AddMovieDto movie);
        void RemoveMovie(string id);
        string ComfirmMovie(string id);
        string RejectMovie(string id);
        void AddToRatedUsersList(string userId, string movieId);
        int GetNumOfActiveMovies();

        List<MovieRankingDto> GetMovieRankings();
    }
}
