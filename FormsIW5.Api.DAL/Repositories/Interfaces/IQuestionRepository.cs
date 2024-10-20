using FormsIW5.Api.DAL.Entities;

namespace FormsIW5.Api.DAL.Repositories.Interfaces;

public interface IQuestionRepository : IApiRepository<QuestionEntity>
{
    public Task<ICollection<QuestionEntity>?> SearchByTextAsync(string textQuery);
    public Task<ICollection<QuestionEntity>?> SearchByDescriptionAsync(string descriptionQuery);
}
