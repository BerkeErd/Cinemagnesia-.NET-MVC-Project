using Application.Dtos;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IWatchListRepository : IRepository<WatchList>
    {
        Task<List<WatchList>> GetByUserIdAsync(string userId);
    }
}
