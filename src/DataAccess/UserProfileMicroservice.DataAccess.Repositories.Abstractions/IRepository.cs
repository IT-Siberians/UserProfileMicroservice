using UserProfileMicroservice.DataAccess.Entities.Base;

namespace UserProfileMicroservice.DataAccess.Repositories.Abstractions;

public interface IRepository<TEntity, in TId>
    where TEntity : Entity<TId>
    where TId : struct, IEquatable<TId>
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(TId id);
    Task<TEntity> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task DeleteAsync(TId id);
}
