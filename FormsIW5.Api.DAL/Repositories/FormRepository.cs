using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.Api.DAL.Repositories;

public class FormRepository : RepositoryBase<FormEntity>, IFormRepository
{
    public FormRepository(FormsIW5DbContext dbContext)
    : base(dbContext)
    {
    }
    public override async Task<FormEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<FormEntity>().Include(f => f.Questions).ThenInclude(q => q.AnswerSelections).SingleOrDefaultAsync(entity => entity.Id == id);
    }
}

