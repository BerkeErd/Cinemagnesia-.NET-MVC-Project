using Application.Dtos;
using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.AppInterfaces
{
    public interface IGenreService
    {
        List<GenreDto> GetAllGenres();
        GenreDto AddGenre(GenreDto genre);
        void RemoveGenre(string id);
        void UpdateGenre(string id, Genre genre);
        Genre GetById(string id);
        List<GenreStatisticDto> GetGenresWithMovies();
    }
}
