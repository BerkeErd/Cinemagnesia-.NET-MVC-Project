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
        void UpdateRating(string id, Rating rating);
        Rating GetById(string id);
    }
}

