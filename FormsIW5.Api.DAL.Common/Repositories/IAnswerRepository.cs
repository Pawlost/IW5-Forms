using FormsIW5.Api.DAL.Common.Entities;

namespace FormsIW5.Api.DAL.Common.Repositories;

public interface IAnswerRepository : IApiRepository<AnswerEntity>
{
    Task<bool> HasQuestionUserAnswer(Guid questionId, string? userId);

    Task<AnswerEntity> GetUserAnswerAsync(Guid questionId, string? userId);
}
