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
        private readonly IDirectorRepository _DirectorRepository;

        public DirectorService(IDirectorRepository DirectorRepository)
        {
            _DirectorRepository = DirectorRepository;
        }
        public void AddDirector(Director director)
        {
            _DirectorRepository.CreateAsync(director).Wait();
        }

        public IEnumerable<Director> GetAllDirectors()
        {
          return _DirectorRepository.GetAllAsync().Result;
        }

        public Director GetById(string id)
        {
            return _DirectorRepository.GetByIdAsync(id).Result;
        }

        public void RemoveDirector(string id)
        {
            _DirectorRepository.DeleteAsync(id).Wait();
        }

        public void UpdateDirector(string id, Director director)
        {
            _DirectorRepository.UpdateAsync(id, director).Wait();
        }
    }
}
