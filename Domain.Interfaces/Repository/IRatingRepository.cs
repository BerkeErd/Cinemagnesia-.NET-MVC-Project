using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IRatingRepository : IRepository<Rating>
    {
         public int GetRateoftheUser(string userId, string movieId);

         bool isExist(string movieId, string userId, out Rating oldRating, out bool isRatingExist);
        void UpdateRating(Rating oldRating, Rating newRating);

        public float CalculateAvgScore(string movieId);
    }
    
}
