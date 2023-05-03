using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<TEntity> CreateAsync(TEntity entity);
        string Update(string id,TEntity entity);
        Task<TEntity> DeleteAsync(string id);
        Task<TEntity> GetByIdAsync(string id, bool includeMovies = false);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
