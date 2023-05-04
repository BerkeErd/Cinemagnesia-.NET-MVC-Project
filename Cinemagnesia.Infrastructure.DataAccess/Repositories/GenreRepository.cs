using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        private readonly DbSet<Genre> _dbSet;
        public GenreRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbSet = _dbContext.Set<Genre>();
        }

        public List<Genre> GetGenresWithMovies()
        {
            return _dbSet.Include(c => c.Movies).ToList();
        }

        public bool IsExistsByName(string name)
        {
            return _dbSet.Any(c => c.Name == name);
        }

        public bool HasItMovie(string id)
        {
            var genre = _dbSet.Include(g => g.Movies).FirstOrDefault(g => g.Id == id);
            if (genre != null && genre.Movies != null && genre.Movies.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
