using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        private readonly ApplicationDbContext _dbContext;
        public MovieService(IMovieRepository movieRepository, IMapper mapper, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public void AddMovie(AddMovieDto movieDto)
        {
            var directors = new List<Director>();
            foreach (var director in movieDto.Directors)
            {
                var existingDirector = _dbContext.Directors.FirstOrDefault(d => d.Name == director.Name);
                directors.Add(existingDirector ?? director);
            }

            var genres = new List<Genre>();
            foreach (var genre in movieDto.Genres)
            {
                var existingGenre = _dbContext.Genres.FirstOrDefault(g => g.Name == genre.Name);
                genres.Add(existingGenre ?? genre);
            }

            var castMembers = new List<CastMember>();
            foreach (var castMember in movieDto.CastMembers)
            {
                var existingCastMember = _dbContext.CastMembers.FirstOrDefault(c => c.Name == castMember.Name);
                castMembers.Add(existingCastMember ?? castMember);
            }

            var movie = new Movie
            {
                CompanyId = movieDto.CompanyId,
                Title = movieDto.Title,
                Description = movieDto.Description,
                PosterPath = movieDto.PosterPath,
                ReleaseDate = movieDto.ReleaseDate,
                ImdbRating = movieDto.ImdbRating,
                Status = movieDto.Status,
                TrailerUrl = movieDto.TrailerUrl,
                Directors = directors,
                Genres = genres,
                CastMembers = castMembers,
                MovieMinutes = movieDto.MovieMinutes,
                Language = movieDto.Language,
                CreatedAt = movieDto.CreatedAt,
                UpdatedAt = movieDto.UpdatedAt
            };

            _movieRepository.CreateAsync(movie).Wait();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllAsync().Result;
        }

        public Movie GetMovieById(string id)
        {
            return _movieRepository.GetByIdAsync(id).Result;
        }

        public void RemoveMovie(string id)
        {
            _movieRepository.DeleteAsync(id).Wait();
        }

        public void UpdateMovie(string id, Movie movie)
        {
            _movieRepository.UpdateAsync(id, movie).Wait();
        }

        public int GetNumOfMovies()
        {
            return _movieRepository.GetNumOfMovies();
        }
    }
}
