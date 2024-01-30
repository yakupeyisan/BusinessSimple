using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Repository;

public interface IRepository<TEntity>
    where TEntity : Entity
{
    IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool isTracking=false,
            int limit = 100,
            int page = 0
        );
    TEntity? Get(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null
    );
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);
}

