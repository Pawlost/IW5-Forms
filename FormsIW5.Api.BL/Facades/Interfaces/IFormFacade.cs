using FormsIW5.Common.BL.Models.Form;
using FormsIW5.Common.BL.Models.User;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IFormFacade : IDetailFacade<FormDetailModel>, IListFacade<FormListModel>, ICreateFacade<UserCreateModel>
{
}
