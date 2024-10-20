using FormsIW5.Common.BL.Models.Question;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IQuestionFacade : IDetailFacade<QuestionDetailModel>, IListFacade<QuestionListModel>
{
    Task<ICollection<QuestionListModel>> SearchByTextOrByDescriptionAsync(string? textQuery, string? descriptionQuery);
}
