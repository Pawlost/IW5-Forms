using FormsIW5.Api.DAL.Entities;
using FormsIW5.Api.DAL.Repositories.Interfaces;

namespace FormsIW5.Api.DAL.Repositories;

public class FormRepository : RepositoryBase<FormEntity>, IFormRepository
{
    public FormRepository(
        FormsIW5DbContext dbContext)
        : base(dbContext)
    {
    }
}
