using AutoMapper;
using FormsIW5.Api.DAL.Entities;

namespace FormsIW5.Api.DAL.Repositories;

public class QuestionRepository : RepositoryBase<QuestionEntity>
{
    public QuestionRepository(
        FormsIW5DbContext dbContext)
        : base(dbContext)
    {
    }
}
