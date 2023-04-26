using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }
        public GenreDto AddGenre(GenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            var response = _genreRepository.CreateAsync(genre).Result;
            var dbGenreDto = _mapper.Map<GenreDto>(response);
            return dbGenreDto;
        }
        public List<GenreDto> GetAllGenres()
        {
            var genres = _genreRepository.GetAllAsync().GetAwaiter().GetResult();
            var genreDtos = _mapper.Map<List<GenreDto>>(genres);
            return genreDtos;
        }

        public Genre GetById(string id)
        {
            return _genreRepository.GetByIdAsync(id).Result;
        }

        public void RemoveGenre(string id)
        {
            _genreRepository.DeleteAsync(id).Wait();
        }

        public void UpdateGenre(string id, Genre genre)
        {
            _genreRepository.UpdateAsync(id, genre).Wait();
        }
    }
}
