using FormsIW5.Api.DAL.Entities;

namespace FormsIW5.Api.DAL.Repositories.Interfaces;

public interface IQuestionRepository : IApiRepository<QuestionEntity>
{
    public ICollection<QuestionEntity>? SearchByText(string textQuery);
    public ICollection<QuestionEntity>? SearchByDescription(string descriptionQuery);
}
