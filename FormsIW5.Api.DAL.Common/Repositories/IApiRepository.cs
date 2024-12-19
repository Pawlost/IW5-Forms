using FormsIW5.Api.DAL.Common.Entities.Interfaces;

namespace FormsIW5.Api.DAL.Common.Repositories;
public interface IApiRepository<TEntity> : IRemoveRepository<TEntity>
    where TEntity : IEntity
{
    Task<IList<TEntity>> GetAllAsync();
    Task<Guid> InsertAsync(TEntity entity);
    Task<Guid?> UpdateAsync(TEntity entity);
}
