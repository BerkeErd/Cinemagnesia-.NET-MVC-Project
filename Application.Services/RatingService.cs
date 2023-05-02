using Application.Interfaces.AppInterfaces;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public void AddRating(Rating rating)
        {
            _ratingRepository.CreateAsync(rating).Wait();
        }

        public IEnumerable<Rating> GetAllRating()
        {
            return _ratingRepository.GetAllAsync().Result;
        }

        public Rating GetById(string id)
        {
            return _ratingRepository.GetByIdAsync(id).Result;
        }

        public void RemoveRating(string id)
        {
            _ratingRepository.DeleteAsync(id).Wait();
        }

        public void UpdateRating(string id, Rating rating)
        {
            _ratingRepository.Update(id, rating);
        }

    }
}
