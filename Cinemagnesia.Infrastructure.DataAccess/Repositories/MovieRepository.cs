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
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly DbSet<Movie> _dbSet;
        public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbSet = _dbContext.Set<Movie>();

        }

        public int GetNumOfMovies()
        {
            return _dbSet.Count();
        }
    }
}
