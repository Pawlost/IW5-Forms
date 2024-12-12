using FormsIW5.BL.Models.Common.Form;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IFormFacade : IUpdateFacade<FormDetailModel>, IListFacade<FormListModel>, ICreateFacade<FormCreateModel>, IUpdateFacade<FormEditModel>
{
}
