using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Domain.Entities.Abstract;
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
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly DbSet<Company> _dbSet;

        public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbSet = _dbContext.Set<Company>();
        }

        public int GetNumOfCompanies()
        {
            return _dbSet.Count();
        }
    }
}
