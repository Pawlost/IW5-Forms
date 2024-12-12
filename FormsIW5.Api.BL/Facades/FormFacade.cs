using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Repositories;
using FormsIW5.BL.Models.Common.Form;

namespace FormsIW5.Api.BL.Facades;

public class FormFacade : FacadeBase<FormEntity, FormListModel, FormDetailModel, FormCreateModel, IFormRepository>, IFormFacade
{
    public FormFacade(IFormRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task UpdateAsync(FormEditModel editModel, string? ownerId)
    {
        await ThrowIfWrongOwnerAsync(editModel.Id, ownerId);
        var entity = mapper.Map<FormEntity>(editModel);
        await repository.UpdateAsync(entity);
    }
}
