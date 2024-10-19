using FormsIW5.Api.DAL.Entities.Interfaces;
using FormsIW5.Api.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.Api.DAL.Repositories;

public class RepositoryBase<TEntity> : IApiRepository<TEntity>, IDisposable
    where TEntity : class, IEntity
{
    protected readonly FormsIW5DbContext dbContext;

    protected RepositoryBase(FormsIW5DbContext dbContext)
    {
     //   dbContext.Database.Migrate();
        this.dbContext = dbContext;
    }

    public virtual IList<TEntity> GetAll()
    {
        return dbContext.Set<TEntity>().ToList();
    }

    public virtual TEntity? GetById(Guid id)
    {
        return dbContext.Set<TEntity>().SingleOrDefault(entity => entity.Id == id);
    }

    public virtual Guid Insert(TEntity entity)
    {
        var createdEntity = dbContext.Set<TEntity>().Add(entity);
        dbContext.SaveChanges();

        return createdEntity.Entity.Id;
    }

    public virtual Guid? Update(TEntity entity)
    {
        if (!Exists(entity.Id))
        {
            return null;
        }

        dbContext.Set<TEntity>().Attach(entity);
        var updatedEntity = dbContext.Set<TEntity>().Update(entity);
        dbContext.SaveChanges();

        return updatedEntity.Entity.Id;
    }

    public virtual void Remove(Guid id)
    {
        var entity = GetById(id);
        if (entity is not null)
        {
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }
    }

    public virtual bool Exists(Guid id)
    {
        return dbContext.Set<TEntity>().Any(entity => entity.Id == id);
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }
}
