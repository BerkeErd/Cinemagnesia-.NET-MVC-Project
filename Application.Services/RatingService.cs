﻿using Application.Interfaces.AppInterfaces;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Razor.TagHelpers;
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
        private readonly IMovieRepository _movieRepository; 
        public RatingService(IRatingRepository ratingRepository, IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
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

        public int GetRateoftheUser(string userId,string movieId)
        {
            
            return _ratingRepository.GetRateoftheUser(userId, movieId);
        }

    }
}
