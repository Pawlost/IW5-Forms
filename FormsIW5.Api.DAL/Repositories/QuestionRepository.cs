using FormsIW5.Api.DAL.Entities;
using FormsIW5.Api.DAL.Repositories.Interfaces;

namespace FormsIW5.Api.DAL.Repositories;

public class QuestionRepository : RepositoryBase<QuestionEntity>, IQuestionRepository
{
    public QuestionRepository(
        FormsIW5DbContext dbContext)
        : base(dbContext)
    {
    }

    public ICollection<QuestionEntity>? SearchByDescription(string descriptionQuery)
    {
        return dbContext.Set<QuestionEntity>().Where(x => x.Description != null && x.Description.Contains(descriptionQuery)).ToList();
    }

    public ICollection<QuestionEntity>? SearchByText(string textQuery)
    {
        return dbContext.Set<QuestionEntity>().Where(x => x.TextAnswer != null && x.TextAnswer.Contains(textQuery)).ToList();
    }

}
