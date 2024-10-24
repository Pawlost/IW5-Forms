using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Queries;

namespace FormsIW5.Api.DAL.Common.Repositories;

public interface IQuestionRepository : IApiRepository<QuestionEntity>
{
    public Task<ICollection<QuestionEntity>?> Search(QuestionQueryObject questionQuery);
}
