using FormsIW5.Api.DAL.Common.Entities.Interfaces;
using FormsIW5.Api.DAL.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.Api.DAL.Repositories;

public abstract class RemoveRepositoryBase<TEntity> : IRemoveRepository<TEntity>, IDisposable
    where TEntity : class, IEntity

{
    protected readonly FormsIW5DbContext dbContext;
    protected RemoveRepositoryBase(FormsIW5DbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public virtual async Task RemoveAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is not null)
        {
            dbContext.Set<TEntity>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(entity => entity.Id == id);
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
