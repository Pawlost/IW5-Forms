using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Entities.Interfaces;
using FormsIW5.Api.DAL.Repositories.Interfaces;
using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Api.BL.Facades;

public class FacadeBase<TEntity, TListModel, TDetailModel, TRepository> : IListFacade<TListModel>, IDetailFacade<TDetailModel>
    where TEntity : IEntity
    where TListModel : IModel
    where TDetailModel : IModel
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

    public Guid Create(TDetailModel detailModel)
    {
        var entity = mapper.Map<TEntity>(detailModel);
        return repository.Insert(entity);
    }

    public Guid CreateOrUpdate(TDetailModel detailModel)
    {
        return repository.Exists(detailModel.Id)
            ? Update(detailModel)!.Value
            : Create(detailModel);
    }

    public void Delete(Guid id)
    {
        repository.Remove(id);
    }

    public TListModel GetSingleListModelById(Guid id)
    {
        var entity = repository.GetById(id);
        return mapper.Map<TListModel>(entity);
    }

    public ICollection<TListModel> GetAll()
    {
        var entities = repository.GetAll();
        return mapper.Map<List<TListModel>>(entities);
    }

    public TDetailModel? GetById(Guid id)
    {
        var entity = repository.GetById(id);
        return mapper.Map<TDetailModel>(entity);
    }

    public Guid? Update(TDetailModel detailModel)
    {
        var entity = mapper.Map<TEntity>(detailModel);
        return repository.Update(entity);
    }
}
