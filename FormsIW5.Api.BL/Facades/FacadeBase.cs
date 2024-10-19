using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Entities.Interfaces;
using FormsIW5.Api.DAL.Repositories.Interfaces;
using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Api.BL.Facades;

public class FacadeBase<TEntity, TListModel, TDetailModel> : IListFacade<TListModel>, IDetailFacade<TDetailModel>
    where TEntity : IEntity
    where TListModel : IModel
    where TDetailModel : IModel
{
    private readonly IApiRepository<TEntity> recipeRepository;
    private readonly IMapper mapper;

    public FacadeBase(
        IApiRepository<TEntity> recipeRepository,
        IMapper mapper)
    {
        this.recipeRepository = recipeRepository;
        this.mapper = mapper;
    }

    public Guid Create(TDetailModel detailModel)
    {
        var recipeEntity = mapper.Map<TEntity>(detailModel);
        return recipeRepository.Insert(recipeEntity);
    }

    public Guid CreateOrUpdate(TDetailModel detailModel)
    {
        return recipeRepository.Exists(detailModel.Id)
            ? Update(detailModel)!.Value
            : Create(detailModel);
    }

    public void Delete(Guid id)
    {
        recipeRepository.Remove(id);
    }

    public TListModel GetList(Guid id)
    {
        var recipeEntity = recipeRepository.GetById(id);
        return mapper.Map<TListModel>(recipeEntity);
    }

    public ICollection<TListModel> GetAll()
    {
        var recipeEntities = recipeRepository.GetAll();
        return mapper.Map<List<TListModel>>(recipeEntities);
    }

    public TDetailModel? GetById(Guid id)
    {
        var recipeEntity = recipeRepository.GetById(id);
        return mapper.Map<TDetailModel>(recipeEntity);
    }

    public Guid? Update(TDetailModel detailModel)
    {
        /*
         
        var recipeEntity = mapper.Map<RecipeEntity>(recipeModel);
        recipeEntity.IngredientAmounts = recipeModel.IngredientAmounts.Select(t =>
            new IngredientAmountEntity
            {
                Id = t.Id,
                Amount = t.Amount,
                Unit = t.Unit,
                RecipeId = recipeEntity.Id,
                IngredientId = t.Ingredient.Id
            }).ToList();
        var result = recipeRepository.Update(recipeEntity);
        return result;
         
         */
        throw new NotImplementedException();
    }
}
