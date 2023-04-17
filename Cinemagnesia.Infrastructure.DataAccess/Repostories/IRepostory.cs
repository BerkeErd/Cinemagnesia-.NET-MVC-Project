using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repostories
{
    public interface IRepostory <TEntity> where TEntity : BaseEntity, new()
    {
        Task<TEntity> CreateAsync (TEntity entity);
        Task<TEntity> UpdateAsync (TEntity entity);
        Task<TEntity> DeleteAsync (Guid id);  
        Task<TEntity> GetByIdAsync (Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
