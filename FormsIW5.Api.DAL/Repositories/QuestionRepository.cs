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

    private IQueryable<QuestionEntity> GetBasicSearchQuery(QuestionQueryObject questionQuery) {
        return dbContext.Set<QuestionEntity>().Where(q => q.FormId == questionQuery.FormId);
    }

    public async Task<ICollection<QuestionEntity>?> SearchByText(QuestionQueryObject questionQuery)
    {
        var query = GetBasicSearchQuery(questionQuery)
            .Where(q => EF.Functions.Like(q.QuestionText, $"%{questionQuery.TextMatch}%"));
        return await query.ToListAsync();
    }

    public async Task<ICollection<QuestionEntity>?> SearchByDescription(QuestionQueryObject questionQuery)
    {
        var query = GetBasicSearchQuery(questionQuery)
            .Where(q => EF.Functions.Like(q.Description, $"%{questionQuery.TextMatch}%"));

        return await query.ToListAsync();
    }

    public async Task<ICollection<Guid>> GetQuestionsIdsAsync(Guid formId)
    {
        return await dbContext.Set<QuestionEntity>().Where(q => q.FormId == formId).Select(q => q.Id).ToListAsync();
    }
}
