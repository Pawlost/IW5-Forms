using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Common.Entities.Interfaces;
using FormsIW5.Api.DAL.Common.Repositories;

namespace FormsIW5.Api.BL.Facades;

public class AppFacadeBase<TRepository, TEntity> : IAppFacadeBase
    where TRepository : IRemoveRepository<TEntity>
    where TEntity : IEntity
{

    protected readonly TRepository repository;

    public AppFacadeBase(
    TRepository repository)
    {
        this.repository = repository;
    }

    protected async Task ThrowIfWrongOwnerAsync(Guid id, string? ownerId)
    {
        if (ownerId is not null)
        {
            var entity = await repository.GetByIdAsync(id);
            if (entity?.OwnerId != ownerId)
            {
                throw new UnauthorizedAccessException();
            }
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await repository.ExistsAsync(id);
    }

    public async Task DeleteAsync(Guid id, string? ownerId)
    {
        await ThrowIfWrongOwnerAsync(id, ownerId);
        await repository.RemoveAsync(id);
    }
}
