using FormsIW5.Api.BL.Queries;
using FormsIW5.Api.DAL.Common.DTO;
using FormsIW5.BL.Models.Common.Question;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IQuestionFacade : IUpdateFacade<QuestionDetailModel>, IListFacade<QuestionEditModel>, ICreateFacade<QuestionCreateModel>
{
    Task<ICollection<QuestionListModel>> SearchByText(QuestionQueryDTO questionQuery);
    Task<ICollection<QuestionListModel>> SearchByDescription(QuestionQueryDTO questionQuery);
    Task UpdateListQuestion(QuestionEditModel questionQuery, OwnerQueryParameters userQuery);
    Task<ICollection<Guid>> GetQuestionsIdsAsync(Guid formId);
}
