using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.AppInterfaces
{
    public interface IRatingService
    {
        IEnumerable<Rating> GetAllRating();
        void AddRating(Rating rating);
        void RemoveRating(string id);
        void UpdateRating(Rating oldRating, Rating newRating);
        Rating GetById(string id);

        int GetRateoftheUser(string userId,string movieId);
    }
}

