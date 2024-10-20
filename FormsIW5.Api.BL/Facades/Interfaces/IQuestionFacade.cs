using FormsIW5.Common.BL.Models.Form;
using FormsIW5.Common.BL.Models.Question;
using FormsIW5.Common.BL.Models.User;

namespace FormsIW5.Api.BL.Facades.Interfaces
{
    public interface IQuestionFacade : IDetailFacade<QuestionDetailModel>, IListFacade<QuestionListModel>
    {
        ICollection<QuestionListModel> SearchByTextOrByDescription(string? textQuery, string? descriptionQuery);
    }
}
