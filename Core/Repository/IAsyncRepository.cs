using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Repository;

public interface IAsyncRepository<TEntity>
    where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool isTracking = false,
            int limit = 100,
            int page = 0
        );
    Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null
    );
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}
