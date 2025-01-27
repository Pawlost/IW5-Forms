using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.BL.Models.Common.Answer;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IAnswerFacade : IUpdateFacade<AnswerDetailModel>, IListFacade<AnswerListModel>, ICreateFacade<AnswerCreateModel>
{
    Task<AnswerDetailModel> GetUserAnswer(Guid questionId, string? userId);
    Task<bool> HasQuestionUserAnswer(Guid questionId, string? userId);
}
