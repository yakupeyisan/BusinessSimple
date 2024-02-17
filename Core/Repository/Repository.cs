using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Repository;

public abstract class Repository<TEntity> : IAsyncRepository<TEntity>, IRepository<TEntity>, IQuery<TEntity>
    where TEntity : Entity
{
    private readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    public virtual IQueryable<TEntity> Query()
    {
        return _context.Set<TEntity>();
    }

    public TEntity Add(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        _context.SaveChanges();
        return entity;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        await _context.SaveChangesAsync();
        return entity;
    }

    public void Delete(TEntity entity)
    {
        Detach(entity);
        _context.Entry(entity).State = EntityState.Added;
        _context.SaveChanges();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        Detach(entity);
        _context.Entry(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        var queryable = Query().Where(predicate);
        if (include != null) queryable = include(queryable);
        return queryable.FirstOrDefault();
    }

    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, bool isTracking = false, int limit = 100, int page = 0)
    {
        var queryable = Query();
        if (isTracking == false) queryable.AsNoTracking();
        if (predicate != null) queryable = queryable.Where(predicate);
        if (include != null) queryable = include(queryable);
        if (orderBy != null) queryable = orderBy(queryable);
        queryable.Skip(page * limit).Take(limit);
        Debug.WriteLine(queryable.ToQueryString());
        return queryable.ToList();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, bool isTracking = false, int limit = 100, int page = 0)
    {
        var queryable = Query();
        if (isTracking == false) queryable.AsNoTracking();
        if (predicate != null) queryable = queryable.Where(predicate);
        if (include != null) queryable = include(queryable);
        if (orderBy != null) queryable = orderBy(queryable);
        queryable.Skip(page * limit).Take(limit);
        Debug.WriteLine(queryable.ToQueryString());
        return await queryable.ToListAsync();
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        var queryable = Query().Where(predicate);
        if (include != null) queryable = include(queryable);
        return await queryable.FirstOrDefaultAsync();
    }

    public TEntity Update(TEntity entity)
    {
        Detach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Detach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    private void Detach(TEntity entity)
    {
        Entity<Guid> Cast(TEntity value)
        {
            return (Entity<Guid>)(object)value;
        }
        if (entity is Entity<Guid>)
        {
            var data = Cast(entity);
            var findLocal=_context.Set<TEntity>().Local.Where(e => Cast(e).Id == data.Id)?.FirstOrDefault();
            if (findLocal != null)
            {
                _context.Entry(findLocal).State = EntityState.Detached;
            }
        }
    }
}

