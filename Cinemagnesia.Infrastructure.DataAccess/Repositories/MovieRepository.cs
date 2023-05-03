using Cinemagnesia.Domain.Domain.Entities.Concrete;
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

        public void AddToRatedUsersList(string userId, string movieId)
        {
            var users = _dbContext.Users.Include(m => m.RatedMovies);
            var movie = _dbContext.Movies.Find(movieId);

            users.FirstOrDefault(x => x.Id == userId).RatedMovies.Add(movie);

            _dbContext.SaveChanges();
        }

        public IQueryable<Movie> GetAllHomeMovies()
        {

            return _dbContext.Movies           
           .Include(m => m.Genres)
           .Where(m => m.Status == ApprovalStatus.Approved);
        }
        
        public IQueryable<Movie> GetAllMovieswithLikes()
        {

            return _dbContext.Movies           
           .Include(m => m.FavoritedUsers)
           .Where(m => m.Status == ApprovalStatus.Approved);
        }


        public int GetNumOfMovies()
        {
            return _dbContext.Movies.Count();
        }

        public void AddRatingToMovie(Movie movie, ApplicationUser user)
        {
            Movie Movie = _dbContext.Movies.FirstOrDefault(movie);
            movie.FavoritedUsers.Add(user);
            _dbContext.SaveChanges();

        }
    }
}
