using FormsIW5.Api.DAL.Common.Queries;
using FormsIW5.BL.Models.Common.Answer;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IAnswerFacade : IUpdateFacade<AnswerDetailModel>, IListFacade<AnswerListModel>, ICreateFacade<AnswerCreateModel>
{
    Task<AnswerDetailModel> GetUserAnswer(Guid questionId, OwnerQueryObject ownerQuery);
    Task<bool> HasQuestionUserAnswer(Guid questionId, OwnerQueryObject ownerQuery);
}
