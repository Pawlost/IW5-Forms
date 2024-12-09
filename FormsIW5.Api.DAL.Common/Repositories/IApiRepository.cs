using FormsIW5.Api.DAL.Common.Entities.Interfaces;

namespace FormsIW5.Api.DAL.Common.Repositories;
public interface IApiRepository<TEntity>
    where TEntity : IEntity
{
    Task<IList<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<Guid> InsertAsync(TEntity entity);
    Task<Guid?> UpdateAsync(TEntity entity);
    Task RemoveAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}