using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.BL.Queries;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Repositories;
using FormsIW5.BL.Models.Common.Form;

namespace FormsIW5.Api.BL.Facades;

public class FormFacade : FacadeBase<FormEntity, FormListModel, FormEditModel, FormCreateModel, IFormRepository>, IFormFacade
{
    public FormFacade(IFormRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<FormDetailModel?> GetFormDetailByOwnerIdAsync(Guid id, OwnerQueryParameters ownerQuery)
    {
        var entity = await repository.GetFormDetailAsync(id);
        var formDetail = mapper.Map<FormDetailModel>(entity);

        formDetail.IsOwner = entity?.OwnerId == ownerQuery.OwnerId;
        return formDetail;
    }
}
