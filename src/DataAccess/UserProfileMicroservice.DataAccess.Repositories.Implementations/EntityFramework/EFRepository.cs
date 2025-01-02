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
        => await DeleteAsync(entity.Id);
    public async Task<bool> DeleteAsync(TId id)
    {
        var entity = await GetByIdAsync(id, CancellationToken.None);
        if (entity is null)
            return false;
        entity.Delete();
        await Context.SaveChangesAsync();
        return entity.SoftDeleted;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => (await Context.Set<TEntity>().AsNoTracking().ToListAsync()).AsEnumerable();

    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken)
        => await Context.Set<TEntity>().FindAsync(id, cancellationToken);

    public async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        Context.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
