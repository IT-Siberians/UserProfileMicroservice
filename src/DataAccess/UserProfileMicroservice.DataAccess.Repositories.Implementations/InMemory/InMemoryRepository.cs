using UserProfileMicroservice.DataAccess.Entities.Base;
using UserProfileMicroservice.DataAccess.Repositories.Abstractions;

namespace UserProfileMicroservice.DataAccess.Repositories.Implementations.InMemory;

public class InMemoryRepository<TEntity, TId>(IEnumerable<TEntity> entities) : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : struct, IEquatable<TId>
{
    protected List<TEntity> EntityList = entities.ToList();

    public InMemoryRepository()
        : this([])
    {
    }

    public Task<TEntity> AddAsync(TEntity entity)
    {
        EntityList.Add(entity);
        return Task.FromResult(entity);
    }

    public Task DeleteAsync(TEntity entity)
    {
        EntityList.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(TId id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null)
            return;
        await DeleteAsync(entity);
    }

    public Task<IEnumerable<TEntity>> GetAllAsync()
        => Task.FromResult(EntityList.AsEnumerable());

    public Task<TEntity?> GetByIdAsync(TId id)
        => Task.FromResult(EntityList.FirstOrDefault(x => x.Id.Equals(id)));

    public Task UpdateAsync(TEntity entity)
    {
        var entityToUpdate = EntityList.FirstOrDefault(x => x.Id.Equals(entity.Id));
        if (entityToUpdate is null)
            return Task.CompletedTask;
        var index = EntityList.IndexOf(entityToUpdate);
        EntityList[index] = entity;
        return Task.CompletedTask;
    }
}
