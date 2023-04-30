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
    public class DirectorRepository : BaseRepository<Director>, IDirectorRepository
    {
        private readonly DbSet<Director> _dbSet;
        public DirectorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbSet = _dbContext.Set<Director>();
        }
        public int GetNumOfDirectors()
        {
            return _dbSet.Count();
        }
    }
}
