using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Entities.Interfaces;
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
        return await dbContext.Set<FormEntity>().AsNoTracking().Include(f => f.Questions).ThenInclude(q => q.QuestionOptions).SingleOrDefaultAsync(entity => entity.Id == id);
    }

    /*
    public override async Task<Guid?> UpdateAsync(FormEntity entity)
    {
        if (!await ExistsAsync(entity.Id))
        {
            return null;
        }

        dbContext.Entry(entity).State = EntityState.Modified;
        dbContext.Entry(entity).Property(p => p.Questions).IsModified = false;
        await dbContext.SaveChangesAsync();

        return entity.Id;
    }*/
}

