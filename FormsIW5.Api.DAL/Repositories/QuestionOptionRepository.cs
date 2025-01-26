using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Repositories;

namespace FormsIW5.Api.DAL.Repositories;

public class QuestionOptionRepository : RemoveRepositoryBase<QuestionOptionEntity>, IQuestionOptionRepository
{
    public QuestionOptionRepository(FormsIW5DbContext dbContext) : base(dbContext)
    {
    }
}
