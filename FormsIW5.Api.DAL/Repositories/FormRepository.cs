using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Interfaces;

namespace FormsIW5.Api.DAL.Repositories;

public class AnswerRepository : RepositoryBase<AnswerEntity>, IAnswerRepository
{
    public AnswerRepository(
        FormsIW5DbContext dbContext)
        : base(dbContext)
    {
    }
}
