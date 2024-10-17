using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Entities.Interfaces;
using FormsIW5.Api.DAL.Repositories;
using FormsIW5.Common.BL.Models.Form;

namespace FormsIW5.Api.BL.Facades
{
    public class FacadeBase<TEntity> : IAppFacade<FormListModel, FormDetailModel>
        where TEntity : IEntity
    {
        private readonly IApiRepository<> recipeRepository;
        private readonly IMapper mapper;

        public RecipeFacade(
            IRecipeRepository recipeRepository,
            IMapper mapper)
        {
            this.recipeRepository = recipeRepository;
            this.mapper = mapper;
        }

        public List<RecipeListModel> GetAll()
        {
            var recipeEntities = recipeRepository.GetAll();
            return mapper.Map<List<RecipeListModel>>(recipeEntities);
        }

        public RecipeDetailModel? GetById(Guid id)
        {
            var recipeEntity = recipeRepository.GetById(id);
            return mapper.Map<RecipeDetailModel>(recipeEntity);
        }

        public Guid CreateOrUpdate(RecipeDetailModel recipeModel)
        {
            return recipeRepository.Exists(recipeModel.Id)
                ? Update(recipeModel)!.Value
                : Create(recipeModel);
        }

        public Guid Create(RecipeDetailModel recipeModel)
        {
            MergeIngredientAmounts(recipeModel);
            var recipeEntity = mapper.Map<RecipeEntity>(recipeModel);
            return recipeRepository.Insert(recipeEntity);
        }

        public Guid? Update(RecipeDetailModel recipeModel)
        {
            MergeIngredientAmounts(recipeModel);

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
        }

        public void MergeIngredientAmounts(RecipeDetailModel recipe)
        {
            var result = new List<RecipeDetailIngredientModel>();
            var ingredientAmountGroups = recipe.IngredientAmounts.GroupBy(t => $"{t.Ingredient.Id}-{t.Unit}");

            foreach (var ingredientAmountGroup in ingredientAmountGroups)
            {
                var ingredientAmountFirst = ingredientAmountGroup.First();
                var totalAmount = ingredientAmountGroup.Sum(t => t.Amount);
                var ingredientAmount = ingredientAmountFirst with { Amount = totalAmount };

                result.Add(ingredientAmount);
            }

            recipe.IngredientAmounts = result;
        }

        public void Delete(Guid id)
        {
            recipeRepository.Remove(id);
        }

        public Guid Create(FormDetailModel detailModeel)
        {
            throw new NotImplementedException();
        }

        public Guid CreateOrUpdate(FormDetailModel detailModeel)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<FormListModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public FormDetailModel? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Guid? Update(FormDetailModel detailModeel)
        {
            throw new NotImplementedException();
        }
    }
}
