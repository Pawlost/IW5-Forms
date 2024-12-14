using FormsIW5.Api.DAL.Common.Entities.Interfaces;
using FormsIW5.Api.DAL.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.Api.DAL.Repositories;

public class RepositoryBase<TEntity> : IApiRepository<TEntity>, IDisposable
    where TEntity : class, IEntity
{
    protected readonly FormsIW5DbContext dbContext;

    protected RepositoryBase(FormsIW5DbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public virtual async Task<IList<TEntity>> GetAllAsync()
    {
        return await dbContext.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(entity => entity.Id == id);
    }

    public virtual async Task<Guid> InsertAsync(TEntity entity)
    {
        var createdEntity = await dbContext.Set<TEntity>().AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return createdEntity.Entity.Id;
    }

    public virtual async Task<Guid?> UpdateAsync(TEntity entity)
    {
        if (!await ExistsAsync(entity.Id))
        {
            return null;
        }

        var updatedEntity = dbContext.Set<TEntity>().Update(entity);
        await dbContext.SaveChangesAsync();

        return updatedEntity.Entity.Id;
    }

    public virtual async Task RemoveAsync(Guid id)
    {
        var entity =  await GetByIdAsync(id);
        if (entity is not null)
        {
            dbContext.Set<TEntity>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }

    public virtual async Task<bool> ExistsAsync(Guid id)
    {
        return await dbContext.Set<TEntity>().AsNoTracking().AnyAsync(entity => entity.Id == id);
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }
}
