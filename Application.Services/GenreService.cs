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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public void AddGenre(Genre genre)
        {
            _genreRepository.CreateAsync(genre).Wait();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _genreRepository.GetAllAsync().Result;
        }

        public Genre GetById(Guid id)
        {
            return _genreRepository.GetByIdAsync(id).Result;
        }

        public void RemoveGenre(Guid id)
        {
            _genreRepository.DeleteAsync(id).Wait();
        }

        public void UpdateGenre(Guid id, Genre genre)
        {
            _genreRepository.UpdateAsync(id, genre).Wait();

        }
    }
}
