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

    public async Task<FormEntity?> GetFormDetailAsync(Guid id) 
    {
        return await dbContext.Set<FormEntity>().AsNoTracking().
            Include(f => f.Questions).SingleOrDefaultAsync(entity => entity.Id == id);
    }
}

