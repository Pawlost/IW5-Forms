using FormsIW5.Api.DAL.Common.Queries;
using FormsIW5.Api.DAL.Entities;

namespace FormsIW5.Api.DAL.Common.Interfaces;

public interface IQuestionRepository : IApiRepository<QuestionEntity>
{
    public Task<ICollection<QuestionEntity>?> Search(QuestionQueryObject questionQuery);
}
