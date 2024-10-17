using AutoMapper;
using FormsIW5.Api.DAL.Entities;

namespace FormsIW5.Api.DAL.Repositories;

public class FormRepository : RepositoryBase<FormEntity>
{
    public FormRepository(
        FormsIW5DbContext dbContext)
        : base(dbContext)
    {
    }
}
