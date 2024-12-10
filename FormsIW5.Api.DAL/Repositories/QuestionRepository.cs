using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Queries;
using FormsIW5.Api.DAL.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.Api.DAL.Repositories;

public class QuestionRepository : RepositoryBase<QuestionEntity>, IQuestionRepository
{
    public QuestionRepository(
        FormsIW5DbContext dbContext)
        : base(dbContext)
    {
    }

    public override async Task<QuestionEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<QuestionEntity>().Include(q => q.Answers).Include(q => q.QuestionOptions).SingleOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task<ICollection<QuestionEntity>?> SearchByText(QuestionQueryObject questionQuery)
    {
        var query = dbContext.Set<QuestionEntity>().Where(q => q.FormId == questionQuery.FormId);

        if (!String.IsNullOrEmpty(questionQuery.TextMatch))
        {
            query = query.Where(q => !String.IsNullOrEmpty(q.QuestionText) && q.QuestionText.Contains(questionQuery.TextMatch));
        }

        return await query.ToListAsync();
    }

    public async Task<ICollection<QuestionEntity>?> SearchByDescription(QuestionQueryObject questionQuery)
    {
        var query = dbContext.Set<QuestionEntity>().Where(q => q.FormId == questionQuery.FormId);

        if (!String.IsNullOrEmpty(questionQuery.TextMatch))
        {
            query = query.Where(q => !String.IsNullOrEmpty(q.Description) && q.Description.Contains(questionQuery.TextMatch));
        }

        return await query.ToListAsync();
    }
}
