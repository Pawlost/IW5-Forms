using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Entities.Interfaces;
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

    public async Task<AnswerEntity?> GetAnswerByOwnerIdAsync(Guid questionId, string ownerId)
    {
        return await dbContext.Set<AnswerEntity>().AsNoTracking().SingleOrDefaultAsync(a => a.QuestionId == questionId && a.OwnerId == ownerId);
    }
}
