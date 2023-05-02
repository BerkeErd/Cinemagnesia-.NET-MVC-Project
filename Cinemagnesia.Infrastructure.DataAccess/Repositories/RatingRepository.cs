using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repositories
{
    public class RatingRepository : BaseRepository<Rating>, IRatingRepository
    {
        public RatingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public int GetRateoftheUser(string userId, string movieId)
        {
            var rating = GetAllAsync()
                .Result
                .FirstOrDefault(r => r.ApplicationUserId == userId && r.MovieId == movieId);

            return Convert.ToInt32(rating?.Score ?? 0);
        }
    }

    
}
