using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Queries;
using FormsIW5.BL.Models.Common.Form;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IFormFacade :  IListFacade<FormListModel>, ICreateFacade<FormCreateModel>, IUpdateFacade<FormEditModel>
{
    Task<FormDetailModel?> GetFormDetailByOwnerIdAsync(Guid id, OwnerQueryObject userQuery);
}
