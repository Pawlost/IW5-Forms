using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Common.Entities.Interfaces;
using FormsIW5.Api.DAL.Common.Repositories;
using FormsIW5.BL.Models.Common.Interfaces;

namespace FormsIW5.Api.BL.Facades;

public class FacadeBase<TEntity, TListModel, TDetailModel, TCreateModel, TRepository> : IListFacade<TListModel>, IDetailFacade<TDetailModel>,
    ICreateFacade<TCreateModel>
    where TEntity : IEntity
    where TListModel : IModel
    where TDetailModel : IModel
    where TCreateModel : ICreateModel
    where TRepository : IApiRepository<TEntity>
{
    protected readonly TRepository repository;
    protected readonly IMapper mapper;

    public FacadeBase(
        TRepository repository,
        IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<Guid> CreateAsync(TCreateModel createModel, string? userId)
    {
        var entity = mapper.Map<TEntity>(createModel);
        entity.OwnerId = userId;
        return await repository.InsertAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await repository.RemoveAsync(id);
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

    public async Task<TDetailModel?> GetByIdAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id);
        return mapper.Map<TDetailModel>(entity);
    }

    public async Task<Guid?> UpdateAsync(TDetailModel detailModel)
    {
        var entity = mapper.Map<TEntity>(detailModel);
        return await repository.UpdateAsync(entity);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await repository.ExistsAsync(id);
    }
}
