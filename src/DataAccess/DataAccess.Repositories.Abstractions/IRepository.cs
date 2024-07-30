using DataAccess.Entities;

namespace DataAccess.Repositories.Abstractions;

public interface IRepository<TEntity, TId>
    where TEntity : IEntity<TId>
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(TId id);
    Task<TEntity> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task DeleteAsync(TId id);
    }
