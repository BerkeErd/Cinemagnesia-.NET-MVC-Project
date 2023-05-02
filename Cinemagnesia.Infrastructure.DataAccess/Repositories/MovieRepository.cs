using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Domain.Entities.Concrete;
using Domain.Entities.Constants;
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
        
        public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
        
        public IQueryable<Movie> GetAllWaitingMovies()
        {

            return _dbContext.Movies
           .Include(m => m.Directors)
           .Include(m => m.Genres)
           .Include(m => m.CastMembers)
           .Include(m => m.MovieComments)
           .Where(m => m.Status == ApprovalStatus.Waiting);
        }

        public int GetNumOfMovies()
        {
            return _dbContext.Movies.Count();
        }
    }
}
