using FormsIW5.Api.BL.Queries;
using FormsIW5.BL.Models.Common.Form;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IFormFacade :  IListFacade<FormListModel>, ICreateFacade<FormCreateModel>, IUpdateFacade<FormEditModel>
{
    Task<FormDetailModel?> GetFormDetailByOwnerIdAsync(Guid id, OwnerQueryParameters userQuery);
}
