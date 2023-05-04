using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly ApplicationDbContext _dbContext;

        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();

        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(string id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(string id, bool includeMovies = false)
        {
            
            if (includeMovies)
            {
                var query = _dbSet.AsQueryable();
                query = query.Include("Movies");
                query = query.Include("Movies.FavoritedUsers");
                query = query.Include("Movies.RatedUsers");
                query = query.Include("Movies.Genres");
                query = query.Include("Movies.Directors");
                query = query.Include("Movies.CastMembers");
                return await query.FirstOrDefaultAsync(e => e.Id == id);
            }
           else
            {
                return await _dbSet.FindAsync(id);
            }

        }
       

        public string Update(string id, TEntity entity)
        {
            var existingEntity = _dbSet.Find(id);
            if (existingEntity == null)
            {
                return "Güncellenemedi. (Varolan entity bulunamadı)";
            }
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return "Güncellendi.";
        }





    }
}
