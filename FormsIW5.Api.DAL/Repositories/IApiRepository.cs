using FormsIW5.Api.DAL.Entities.Interfaces;

namespace FormsIW5.Api.DAL.Repositories;

public interface IApiRepository<TEntity>
    where TEntity : IEntity
{
    IList<TEntity> GetAll();
    TEntity? GetById(Guid id);
    Guid Insert(TEntity entity);
    Guid? Update(TEntity entity);
    void Remove(Guid id);
    bool Exists(Guid id);
}
