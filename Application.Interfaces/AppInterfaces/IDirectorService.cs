using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.AppInterfaces
{
    public interface IDirectorService
    {
        IEnumerable<Director> GetAllGenres();
        void AddDirector(Director genre);
        void RemoveDirector(string id);
        void UpdateDirector(string id, Director genre);
        Director GetById(string id);
    }
}
