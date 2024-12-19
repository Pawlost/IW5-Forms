using FormsIW5.Api.DAL.Common.Entities.Interfaces;

namespace FormsIW5.Api.DAL.Common.Repositories;

public interface IRemoveRepository<TEntity>
    where TEntity : IEntity
{
    Task<TEntity?> GetByIdAsync(Guid id);

    Task RemoveAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);
}
