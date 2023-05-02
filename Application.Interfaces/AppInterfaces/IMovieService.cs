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
        List<MovieDto> GetAllWaitingMovies();
        List<HomeMovieDto> GetAllHomeMovies();
        void AddMovie(AddMovieDto movie);
        void RemoveMovie(string id);
        string ComfirmMovie(string id);
        string RejectMovie(string id);
        int GetNumOfMovies();
    }
}
