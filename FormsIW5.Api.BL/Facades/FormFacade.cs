using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Repositories;
using FormsIW5.BL.Models.Common.Form;
using FormsIW5.Common.BL.Models.Question;

namespace FormsIW5.Api.BL.Facades;

public class FormFacade : FacadeBase<FormEntity, FormListModel, FormDetailModel, FormCreateModel, IFormRepository>, IFormFacade
{
    public FormFacade(IFormRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
