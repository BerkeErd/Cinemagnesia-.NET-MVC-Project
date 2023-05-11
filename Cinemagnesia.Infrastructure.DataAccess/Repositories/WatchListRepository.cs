using Application.Dtos;
using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repositories
{
    public class WatchListRepository : BaseRepository<WatchList>, IWatchListRepository
    {
        public WatchListRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<WatchList>> GetByUserIdAsync(string userId)
        {
            return await _dbContext.WatchList
                .Where(w => w.ApplicationUserId == userId)
                .Include(w => w.Movie)
                .ToListAsync();
        }
    }
}
