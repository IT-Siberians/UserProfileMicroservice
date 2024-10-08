using UserProfileMicroservice.DataAccess.Entities.Base;
using UserProfileMicroservice.DataAccess.EntityFramework;
using UserProfileMicroservice.DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace UserProfileMicroservice.DataAccess.Repositories.Implementations.EntityFramework;

public class EFRepository<TEntity, TId>(ApplicationDbContext context) : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : struct, IEquatable<TId>
{
    protected ApplicationDbContext Context => context;

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        context.Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(TId id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null)
            return false;
        return await DeleteAsync(entity);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => (await context.Set<TEntity>().AsNoTracking().ToListAsync()).AsEnumerable();

    public virtual async Task<TEntity?> GetByIdAsync(TId id)
        => await context.Set<TEntity>().FindAsync(id);

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        context.Update(entity);
        await context.SaveChangesAsync();
        return true;
    }
}
