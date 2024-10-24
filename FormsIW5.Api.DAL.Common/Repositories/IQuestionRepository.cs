using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Queries;

namespace FormsIW5.Api.DAL.Common.Interfaces;

public interface IQuestionRepository : IApiRepository<QuestionEntity>
{
    public Task<ICollection<QuestionEntity>?> Search(QuestionQueryObject questionQuery);
}
