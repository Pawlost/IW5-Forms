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

    public override async Task<AnswerEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<AnswerEntity>().SingleOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task<ICollection<AnswerEntity>> GetFormAnswersAsync(Guid formId)
    {
        return await dbContext.Set<FormEntity>().Include(f => f.Questions).ThenInclude(q => q.Answers).SelectMany(f => f.Questions).SelectMany(q => q.Answers).ToListAsync();
    }
}
