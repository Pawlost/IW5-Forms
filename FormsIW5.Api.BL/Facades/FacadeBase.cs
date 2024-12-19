using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Common.Entities.Interfaces;
using FormsIW5.Api.DAL.Common.Repositories;
using FormsIW5.BL.Models.Common.Interfaces;

namespace FormsIW5.Api.BL.Facades;

public class FacadeBase<TEntity, TListModel, TEditModel, TCreateModel, TRepository> : AppFacadeBase<TRepository, TEntity>, IListFacade<TListModel>, IUpdateFacade<TEditModel>,
    ICreateFacade<TCreateModel>
    where TEntity : IEntity
    where TListModel : IModel
    where TEditModel : IModel
    where TCreateModel : ICreateModel
    where TRepository : IApiRepository<TEntity>
{
    protected readonly IMapper mapper;

    public FacadeBase(
        TRepository repository,
        IMapper mapper) : base(repository)
    {
        this.mapper = mapper;
    }

    public async Task<Guid> CreateAsync(TCreateModel createModel, string? userId)
    {
        var entity = mapper.Map<TEntity>(createModel);
        entity.OwnerId = userId;
        return await repository.InsertAsync(entity);
    }

    public async Task<TListModel> GetSingleListModelByIdAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id);
        return mapper.Map<TListModel>(entity);
    }

    public async Task<ICollection<TListModel>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();
        return mapper.Map<List<TListModel>>(entities);
    }

    public async Task<TEditModel?> GetByIdAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id);
        return mapper.Map<TEditModel>(entity);
    }

    public virtual async Task<Guid?> UpdateAsync(TEditModel detailModel, string? ownerId)
    {
        await ThrowIfWrongOwnerAsync(detailModel.Id, ownerId);
        var entity = mapper.Map<TEntity>(detailModel);
        entity.OwnerId = ownerId;
        return await repository.UpdateAsync(entity);
    }
}
