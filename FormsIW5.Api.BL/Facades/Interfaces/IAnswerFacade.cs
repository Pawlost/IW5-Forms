using FormsIW5.Api.BL.Queries;
using FormsIW5.BL.Models.Common.Answer;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IAnswerFacade : IUpdateFacade<AnswerDetailModel>, IListFacade<AnswerListModel>, ICreateFacade<AnswerCreateModel>
{
    Task<AnswerDetailModel> GetUserAnswer(Guid questionId, OwnerQueryParameters ownerQuery);
    Task<bool> HasQuestionUserAnswer(Guid questionId, OwnerQueryParameters ownerQuery);
}
