using Application.Dtos;
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
            Movie movie = _dbContext.Movies
                .Include(m => m.Directors)
                .Include(m => m.Genres)
                .Include(m => m.CastMembers)
                .Include(m => m.MovieComments)
                    .ThenInclude(mc => mc.User)
                .FirstOrDefault(m => m.Id == id && m.Status == ApprovalStatus.Approved);

            if (movie != null)
            {
                movie.MovieComments = movie.MovieComments.OrderByDescending(mc => mc.CreatedAt).ToList();
                return movie;
            }
            else
            {
                return new Movie();
            }
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
            var user = users.FirstOrDefault(x => x.Id == userId);
            var movie = _dbContext.Movies.Find(movieId);

            if (movie != null && user != null)
            {
                user.RatedMovies.Add(movie);
                _dbContext.SaveChanges();
            }

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


        public int GetNumOfActiveMovies()
        {
            return _dbContext.Movies.Where(m => m.Status == ApprovalStatus.Approved).Count();
        }

        public void UpdateAverageScore(string movieId, float rating)
        {
            var movie = _dbContext.Movies.FirstOrDefault(m => m.Id == movieId);

            if (movie != null)
            {
                movie.CinemagAvgScore = rating;
            }
        }
        public void AddRatingToMovie(Movie movie, ApplicationUser user)
        {
            Movie Movie = _dbContext.Movies.FirstOrDefault(movie);
            if (movie != null)
            {
                movie.FavoritedUsers.Add(user);
                _dbContext.SaveChanges();
            }
        }

        public List<MovieRankingDto> GetMovieRankings()
        {
            var movies = _dbContext.Movies.Where(m => m.CinemagAvgScore > 0).ToList();

            return movies.Select(m => new MovieRankingDto
            {
                Title = m.Title,
                CinemagnesiaAvgScore = m.CinemagAvgScore
            }).OrderByDescending(m => m.CinemagnesiaAvgScore).ToList();
        }

        public async Task<List<LanguageStatisticDto>> GetLanguageStatistics()
        {
            var result = await _dbContext.Movies
                 .Where(m => m.Status == ApprovalStatus.Approved)
                 .GroupBy(m => m.Language)
                 .Select(g => new LanguageStatisticDto
                 {
                     Name = g.Key,
                     MovieCount = g.Count()
                 })
                 .ToListAsync();

            return result;
        }

        public async Task<string> GetMostRatedMovie()
        {
            var movie = await _dbContext.Movies
                .Where(m => m.Status == ApprovalStatus.Approved)
                .OrderByDescending(m => m.CinemagAvgScore)
                .Select(m => m.Title)
                .FirstOrDefaultAsync();

            return movie ?? "Film bulunamadı.";
        }
    }
}
