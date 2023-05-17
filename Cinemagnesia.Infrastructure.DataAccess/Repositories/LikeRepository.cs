using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repositories
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
