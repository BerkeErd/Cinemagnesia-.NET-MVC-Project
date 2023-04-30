using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using Infrastructure.DataAccess.Repositories;
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
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public void AddMovie(AddMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);
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
