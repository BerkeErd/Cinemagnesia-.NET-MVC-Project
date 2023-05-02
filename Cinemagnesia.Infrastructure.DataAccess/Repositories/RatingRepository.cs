using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
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

        public bool isExist(string movieId, string userId, out string ratingId, out bool isExist)
        {
            var user = _dbContext.Users.Include(m => m.RatedMovies).FirstOrDefault(x=> x.Id == userId);

            if (user != null)
            {
                if (user.RatedMovies != null)
                {
                    foreach (var movie in user.RatedMovies)
                    {
                        movie.Id = movieId;
                        var rating = _dbContext.Ratings.FirstOrDefault(r => r.MovieId == movie.Id && r.User.Id == user.Id);
                        string ratingsid = rating.Id;
                        ratingId = ratingsid;
                        isExist = true;
                        return true;
                    }
                    ratingId = "";
                    isExist = false;
                    return false;
                }
                ratingId = "";
                isExist = false;
                return false;
            }
            ratingId = "";
            isExist = false;
            return false;


        }
        public int GetRateoftheUser(string userId, string movieId)
        {
            var rating = GetAllAsync()
                .Result
                .FirstOrDefault(r => r.ApplicationUserId == userId && r.MovieId == movieId);

            return Convert.ToInt32(rating?.Score ?? 0);
        }

        public void UpdateRating(string id, Rating entity)
        {
            var existingEntity = _dbContext.Ratings.Find(id);

            if (existingEntity != null)
            {
                // Update the properties of the existing entity
                existingEntity.Score = entity.Score;
                existingEntity.ApplicationUserId = entity.ApplicationUserId;
                existingEntity.MovieId = entity.MovieId;

                // Save the changes to the database
                _dbContext.SaveChanges();
            }
        }

    }


}
