using Application.Interfaces.AppInterfaces;
using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using Infrastructure.DataAccess.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly UserManager<ApplicationUser> _usermanager;
        public RatingService(IRatingRepository ratingRepository, IMovieRepository movieRepository, UserManager<ApplicationUser> usermanager)
        {
            _movieRepository = movieRepository;
            _ratingRepository = ratingRepository;
            _usermanager = usermanager;
        }

        public float CalculateAvgScore(string movieId)
        {
           return _ratingRepository.CalculateAvgScore(movieId);
        }

        public void SetAvgScore(float score, string movieId)
        {
          var movie =  _movieRepository.GetByIdAsync(movieId).Result;
          
            if(movie != null)
            {
                movie.CinemagAvgScore = CalculateAvgScore(movieId);
            }

        }

        public void AddRating(Rating rating)
        {
            if (_ratingRepository.isExist(rating.MovieId, rating.ApplicationUserId, out Rating oldRating, out bool isRatingExist))
            {
                UpdateRating(oldRating, rating);
                SetAvgScore(rating.Score, rating.MovieId);
            }
            else
            {
                _ratingRepository.CreateAsync(rating).Wait();
                SetAvgScore(rating.Score, rating.MovieId);
            }
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

        public void UpdateRating(Rating oldRating, Rating newRating)
        {
            _ratingRepository.UpdateRating(oldRating, newRating);
        }

        public int GetRateoftheUser(string userId,string movieId)
        {
            var user = _usermanager.Users.Include(u => u.RatedMovies).FirstOrDefault(u => u.Id == userId);

            var ratedMovies = user.RatedMovies;
            if (ratedMovies != null)
            {
                foreach (var movie in ratedMovies) // Film daha önce oylanmış mı?
                {
                    if (movie.Id == movieId)
                    {
                        return _ratingRepository.GetRateoftheUser(userId, movie.Id); // set the Rate to the user's previous rating
                    }
                }
            }
            return _ratingRepository.GetRateoftheUser(userId, movieId);
        }

       

    }
}
