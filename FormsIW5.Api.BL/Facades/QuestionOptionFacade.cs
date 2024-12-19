using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Repositories;
namespace FormsIW5.Api.BL.Facades;

public class QuestionOptionFacade : AppFacadeBase<IQuestionOptionRepository, QuestionOptionEntity>, IQuestionOptionFacade
{
    public QuestionOptionFacade(IQuestionOptionRepository repository) : base(repository)
    {
    }
}
