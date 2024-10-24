using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Interfaces;
using FormsIW5.Api.DAL.Entities.Interfaces;

namespace FormsIW5.Api.DAL.Repositories;

public class FormRepository : RepositoryBase<FormEntity>, IFormRepository
{
    public FormRepository(FormsIW5DbContext dbContext)
    : base(dbContext)
    {
    }

    public override async Task<Guid> InsertAsync(FormEntity entity)
    {
        return Guid.NewGuid();
    }
}

