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
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository DirectorRepository)
        {
            _directorRepository = DirectorRepository;
        }
        public void AddDirector(Director director)
        {
            _directorRepository.CreateAsync(director).Wait();
        }

        public IEnumerable<Director> GetAllDirectors()
        {
            return _directorRepository.GetAllAsync().Result;
        }

        public Director GetById(string id)
        {
            return _directorRepository.GetByIdAsync(id).Result;
        }

        public void RemoveDirector(string id)
        {
            _directorRepository.DeleteAsync(id).Wait();
        }

        public void UpdateDirector(string id, Director director)
        {
            _directorRepository.UpdateAsync(id, director).Wait();
        }

        public int GetNumOfDirectors()
        {
            return _directorRepository.GetNumOfDirectors();
        }
    }
}
