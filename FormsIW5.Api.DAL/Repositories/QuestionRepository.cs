using FormsIW5.Api.DAL.Entities;
using FormsIW5.Api.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.Api.DAL.Repositories;

public class QuestionRepository : RepositoryBase<QuestionEntity>, IQuestionRepository
{
    public QuestionRepository(
        FormsIW5DbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<ICollection<QuestionEntity>?> SearchByDescriptionAsync(string descriptionQuery)
    {
        return await dbContext.Set<QuestionEntity>().Where(x => x.Description != null && x.Description.Contains(descriptionQuery)).ToListAsync();
    }

    public async Task<ICollection<QuestionEntity>?> SearchByTextAsync(string textQuery)
    {
        return await dbContext.Set<QuestionEntity>().Where(x => x.TextAnswer != null && x.TextAnswer.Contains(textQuery)).ToListAsync();
    }

}
