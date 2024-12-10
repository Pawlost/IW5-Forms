using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Queries;
using FormsIW5.Api.DAL.Common.Repositories;
using FormsIW5.BL.Models.Common.Question;

namespace FormsIW5.Api.BL.Facades;

public class QuestionFacade : FacadeBase<QuestionEntity, QuestionEditModel, QuestionDetailModel, QuestionCreateModel, IQuestionRepository>, IQuestionFacade
{
    public QuestionFacade(IQuestionRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<ICollection<QuestionListModel>> SearchByText(QuestionQueryObject questionQuery)
    {
        var result = await repository.SearchByText(questionQuery);
        return mapper.Map<List<QuestionListModel>>(result);
    }

    public async Task<ICollection<QuestionListModel>> SearchByDescription(QuestionQueryObject questionQuery)
    {
        var result = await repository.SearchByDescription(questionQuery);
        return mapper.Map<List<QuestionListModel>>(result);
    }

    public async Task UpdateListQuestion(QuestionEditModel model)
    {
        var entity = mapper.Map<QuestionEntity>(model);
        await repository.UpdateAsync(entity);
    }
}
