using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;

namespace DataAccess.Repositories.Implementations.InMemory;

public class InMemoryRepository<TEntity, TId>(IEnumerable<TEntity> entities) : IRepository<TEntity, TId>
    where TEntity : IEntity<TId>
    where TId : struct
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
        => DeleteAsync(entity.Id);

    public Task DeleteAsync(TId id)
    {
        for (int i = 0; i < EntityList.Count; i++)
            if (EntityList[i].Id.Equals(id))
        {
                EntityList.RemoveAt(i);
                break;
            }
        return Task.CompletedTask;
    }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        => Task.FromResult(EntityList.AsEnumerable());

    public Task<TEntity?> GetByIdAsync(TId id)
        => Task.FromResult(EntityList.FirstOrDefault(x => x.Id.Equals(id)));

        public Task UpdateAsync(TEntity entity)
    {
        for (int i = 0; i < EntityList.Count; i++)
            if (EntityList[i].Id.Equals(entity.Id))
            {
                EntityList[i] = entity;
                break;
            }
        return Task.CompletedTask;
    }

}
