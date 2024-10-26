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

    public override async Task<Guid> InsertAsync(AnswerEntity entity)
    {
        var question = await dbContext.Set<AnswerEntity>().AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public override async Task<AnswerEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<AnswerEntity>().Include(a => a.SelectedAnswer).SingleOrDefaultAsync(entity => entity.Id == id);
    }
}