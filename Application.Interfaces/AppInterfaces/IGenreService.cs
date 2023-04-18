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
        IEnumerable<Genre> GetAllGenres();
        void AddGenre(Genre genre);
        void RemoveGenre(string id);
        void UpdateGenre(string id, Genre genre);
        Genre GetById(string id);
    }
}
