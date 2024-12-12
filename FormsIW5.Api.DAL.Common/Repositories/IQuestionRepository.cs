using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Queries;

namespace FormsIW5.Api.DAL.Common.Repositories;

public interface IQuestionRepository : IApiRepository<QuestionEntity>
{
    Task<ICollection<QuestionEntity>?> SearchByText(QuestionQueryObject questionQuery);
    Task<ICollection<QuestionEntity>?> SearchByDescription(QuestionQueryObject questionQuery);
    Task<ICollection<Guid>> GetQuestionsIdsAsync(Guid formId);
}
