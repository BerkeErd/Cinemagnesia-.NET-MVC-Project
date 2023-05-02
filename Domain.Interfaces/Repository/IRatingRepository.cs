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

         bool isExist(string movieId, string userId, out string ratingId, out bool isRatingExist);
        void UpdateRating(string id, Rating entity);
    }
    
}
