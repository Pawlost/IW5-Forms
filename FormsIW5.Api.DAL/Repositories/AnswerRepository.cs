using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.Api.DAL.Repositories;

public class AnswerRepository : RepositoryBase<AnswerEntity>, IAnswerRepository
{
    public AnswerRepository(
        FormsIW5DbContext dbContext)
        : base(dbContext)
    {
    }
    public async Task<bool> HasQuestionUserAnswer(Guid questionId, string? userId)
    {
        return await dbContext.Set<AnswerEntity>().AsNoTracking().Include(a => a.Question).AnyAsync(a => a.QuestionId == questionId && a.OwnerId == userId);
    }

    public async Task<AnswerEntity> GetUserAnswerAsync(Guid questionId, string? userId)
    {
        return await dbContext.Set<AnswerEntity>().AsNoTracking().Include(a => a.Question).FirstAsync(a => a.QuestionId == questionId && a.OwnerId == userId);
    }
}
