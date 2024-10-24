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

    public override async Task<Guid> InsertAsync(FormEntity entity)
    {
        var user = await dbContext.Set<UserEntity>().Include(u => u.Forms).SingleOrDefaultAsync(u => u.Id == entity.UserId);
        user?.Forms.Add(entity);
        await dbContext.SaveChangesAsync();

        return entity.Id;
    }
    public override async Task<FormEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<FormEntity>().Include(q => q.Questions).SingleOrDefaultAsync(entity => entity.Id == id);
    }
}

