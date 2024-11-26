using FormsIW5.BL.Models.Common.Form;
using FormsIW5.Common.BL.Models.Question;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IFormFacade : IDetailFacade<FormDetailModel>, IListFacade<FormListModel>, ICreateFacade<FormCreateModel>
{
}
