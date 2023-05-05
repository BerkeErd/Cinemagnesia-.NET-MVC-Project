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
    public interface IGenreRepository : IRepository<Genre>
    {
        List<Genre> GetGenresWithMovies();
        bool IsExistsByName(string name);
        bool HasItMovie(string id);
        Task<string> GetMostRatedGenre();
        IEnumerable<GenreScoreDto> GetGenreRankings();
    }
}
