using Domain.Entities.Concrete;
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
        IEnumerable<Movie> GetAllMovies();
        void AddMovie(Movie movie);
        void RemoveMovie(string id);
        void UpdateMovie(string id, Movie movie);

        //IEnumerable<Movie> GetMoviesByDirectorId(string directorId);

    }
}
