using FormsIW5.Common.BL.Models.Form;
using FormsIW5.Common.BL.Models.Question;

namespace FormsIW5.Api.BL.Facades.Interfaces
{
    public interface IFormFacade : IDetailFacade<QuestionDetailModel>, IListFacade<QuestionListModel>
    {
    }
}
