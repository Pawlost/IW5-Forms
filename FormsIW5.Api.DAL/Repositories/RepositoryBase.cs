using FormsIW5.Api.DAL.Common.Entities.Interfaces;
using FormsIW5.Api.DAL.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.Api.DAL.Repositories;

public class RepositoryBase<TEntity> : RemoveRepositoryBase<TEntity>, IApiRepository<TEntity>
    where TEntity : class, IEntity
{
    public RepositoryBase(FormsIW5DbContext dbContext) : base(dbContext)
    {
    }

    public virtual async Task<IList<TEntity>> GetAllAsync()
    {
        return await dbContext.Set<TEntity>().ToListAsync();
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
}
