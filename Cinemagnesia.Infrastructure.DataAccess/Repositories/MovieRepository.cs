using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Domain.Entities.Concrete;
using Domain.Entities.Constants;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        public Movie GetMovieById(string id)
        {
            return _dbContext.Movies
                .Include(m => m.Directors)
                .Include(m => m.Genres)
                .Include(m => m.CastMembers)
                .Include(m => m.MovieComments)
                .FirstOrDefault(m => m.Id == id && m.Status == ApprovalStatus.Approved);
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


        public IQueryable<Movie> GetAllHomeMovies()
        {

            return _dbContext.Movies           
           .Include(m => m.Genres)
           .Where(m => m.Status == ApprovalStatus.Approved);
        }


        public int GetNumOfMovies()
        {
            return _dbContext.Movies.Count();
        }
    }
}
