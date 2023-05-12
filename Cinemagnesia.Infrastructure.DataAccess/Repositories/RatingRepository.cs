using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using Infrastructure.DataAccess.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repositories
{
    public class RatingRepository : BaseRepository<Rating>, IRatingRepository
    {
        
        public RatingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
           
        }

        public bool isExist(string movieId, string userId, out Rating oldRating, out bool isExist)
        {
            oldRating = null;
            isExist = false;

            var user = _dbContext.Users
                .Include(u => u.RatedMovies)
                .FirstOrDefault(u => u.Id == userId);

            if (user != null && user.RatedMovies != null)
            {
                foreach (var movie in user.RatedMovies)
                {
                    if (movie.Id == movieId)
                    {
                        var rating = _dbContext.Ratings
                            .FirstOrDefault(r => r.MovieId == movieId && r.ApplicationUserId == userId);

                        if (rating != null)
                        {
                            oldRating = rating;
                            isExist = true;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public int GetRateoftheUser(string userId, string movieId)
        {
            var rating = GetAllAsync()
                .Result
                .FirstOrDefault(r => r.ApplicationUserId == userId && r.MovieId == movieId);

            return Convert.ToInt32(rating?.Score ?? 0);
        }

        public void UpdateRating(Rating oldRating, Rating newRating)
        {
            if(oldRating == null || newRating == null) return;

            var existingRating = _dbContext.Ratings.Find(new object[] { oldRating.ApplicationUserId, oldRating.MovieId});


            if (existingRating != null)
            {
                existingRating.Score = newRating.Score;
                existingRating.ApplicationUserId = newRating.ApplicationUserId;
                existingRating.MovieId = newRating.MovieId;

                _dbContext.SaveChanges();
            }
        }
        public Rating GetByUserIdandMovieId(string userId, string movieId)
        {
            if (userId == null || movieId == null)
            {
                return new Rating();
            }

            return _dbContext.Ratings.FirstOrDefault(r => r.ApplicationUserId == userId && r.MovieId == movieId);
        }

        public float CalculateAvgScore(string movieId)
        {
            var ratings = _dbContext.Ratings.Where(r => r.MovieId == movieId && r.Score > 0).ToList();

            if (ratings.Count == 0)
            {
                return 0f;
            }

            var totalScore = ratings.Sum(r => r.Score);
            var avgScore = (float)totalScore / ratings.Count;

            return avgScore;
        }


    }


}
