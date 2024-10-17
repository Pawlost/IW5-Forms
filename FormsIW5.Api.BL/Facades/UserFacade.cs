using AutoMapper;
using FormsIW5.Api.DAL.Entities;
using FormsIW5.Api.DAL.Repositories.Interfaces;
using FormsIW5.Common.BL.Models.Form;
using FormsIW5.Common.BL.Models.Question;

namespace FormsIW5.Api.BL.Facades;

public class FormFacade : FacadeBase<FormEntity, FormListModel, FormDetailModel>
{
    public FormFacade(IApiRepository<FormEntity> recipeRepository, IMapper mapper) : base(recipeRepository, mapper)
    {
    }
}
