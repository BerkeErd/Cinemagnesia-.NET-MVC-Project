using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Domain.Entities.Concrete;
using Domain.Entities.Constants;
using Domain.Interfaces.Repository;
using Infrastructure.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
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
        private readonly ICompanyRepository _companyRepository;
        private readonly ApplicationDbContext _dbContext;
        public MovieService(IMovieRepository movieRepository, IMapper mapper, ApplicationDbContext dbContext, ICompanyRepository companyRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _movieRepository = movieRepository;
            _companyRepository = companyRepository;
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

        public List<MovieDto> GetAllWaitingMovies()
        {
            var movies = _movieRepository.GetAllWaitingMovies().ToList();
            var movieDtos = _mapper.Map<List<MovieDto>>(movies);

            foreach (var movieDto in movieDtos)
            {
                var companyId = movies.Where(m => m.Id==movieDto.Id).Select(m => m.CompanyId).FirstOrDefault();
                var companyName = _dbContext.Companies.Where(c => c.Id == companyId).Select(c => c.Name).FirstOrDefault();
                movieDto.CompanyName = companyName;
            }

            return movieDtos;
        }

        public List<MovieDto> GetAllMovieswithLikes()
        {
            var movies = _movieRepository.GetAllMovieswithLikes().ToList();
            var movieDto = _mapper.Map<List<MovieDto>>(movies);
            return movieDto;
        }
        public List<MovieDto> GetMoviesByCompanyId(string companyId, bool includeMovies = false)
        {
            var company = _companyRepository.GetByIdAsync(companyId, includeMovies).Result;

            if (company == null)
            {
                throw new NotFoundException($"Company with ID {companyId} not found");
            }

            var movies = company.Movies;

            return _mapper.Map<List<MovieDto>>(movies);
        }
        public MovieDto GetMovieDtoById(string id)
        {
            var movie = _movieRepository.GetMovieById(id);
            var movieDto = _mapper.Map<MovieDto>(movie);
            return movieDto;
        }
        public List<HomeMovieDto> GetAllHomeMovies()
        {
            var movies = _movieRepository.GetAllHomeMovies().ToList();
            var movieDtos = _mapper.Map<List<HomeMovieDto>>(movies);

            return movieDtos;
        }
        public Movie GetMovieById(string id)
        {
            return _movieRepository.GetByIdAsync(id).Result;
        }

        public void RemoveMovie(string id)
        {
            _movieRepository.DeleteAsync(id).Wait();
        }

        public  string ComfirmMovie(string id)
        {
            var movies = _movieRepository.GetAllWaitingMovies();
            Movie dbMovie = movies.SingleOrDefault(x=>x.Id==id); // belirtilen id'ye sahip filmi bul

            if (dbMovie != null) // film veritabanında varsa güncelleme yap
            {
                dbMovie.Status = ApprovalStatus.Approved;
                dbMovie.UpdatedAt = DateTime.Now;

                 var updatedMovie =  _movieRepository.Update(id,dbMovie);

                if (updatedMovie != null)
                {
                    return "Başarılı";
                }
                else
                {
                    return "Güncelleme başarısız";
                }
            }
            else // belirtilen id'ye sahip bir film bulunamazsa hata fırlat
            {
                return "Invalid movie id";
            }
        }

        public string RejectMovie(string id)
        {
            var movies = _movieRepository.GetAllWaitingMovies();
            Movie dbMovie = movies.SingleOrDefault(x => x.Id == id); // belirtilen id'ye sahip filmi bul

            if (dbMovie != null) // film veritabanında varsa güncelleme yap
            {
                dbMovie.Status = ApprovalStatus.Rejected;
                dbMovie.UpdatedAt = DateTime.Now;

                var updatedMovie = _movieRepository.Update(id, dbMovie);

                if (updatedMovie != null)
                {
                    return "Başarılı";
                }
                else
                {
                    return "Güncelleme başarısız";
                }
            }
            else // belirtilen id'ye sahip bir film bulunamazsa hata fırlat
            {
                return "Invalid movie id";
            }
        }

        public void AddToRatedUsersList(string userId, string movieId)
        {
            _movieRepository.AddToRatedUsersList(userId, movieId);
        }
        public int GetNumOfMovies()
        {
            return _movieRepository.GetNumOfActiveMovies();
        }
    }
}
