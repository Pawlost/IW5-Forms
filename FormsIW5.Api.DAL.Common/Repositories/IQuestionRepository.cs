using FormsIW5.Api.DAL.Common.DTO;
using FormsIW5.Api.DAL.Common.Entities;

namespace FormsIW5.Api.DAL.Common.Repositories;

public interface IQuestionRepository : IApiRepository<QuestionEntity>
{
    Task<ICollection<QuestionEntity>?> SearchByText(QuestionQueryDTO questionQuery);
    Task<ICollection<QuestionEntity>?> SearchByDescription(QuestionQueryDTO questionQuery);
    Task<ICollection<Guid>> GetQuestionsIdsAsync(Guid formId);
}
