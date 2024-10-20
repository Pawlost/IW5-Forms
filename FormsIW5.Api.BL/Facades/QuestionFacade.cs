using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Entities;
using FormsIW5.Api.DAL.Repositories.Interfaces;
using FormsIW5.Common.BL.Models.Question;

namespace FormsIW5.Api.BL.Facades;

public class QuestionFacade : FacadeBase<QuestionEntity, QuestionListModel, QuestionDetailModel, IQuestionRepository>, IQuestionFacade
{
    public QuestionFacade(IQuestionRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public ICollection<QuestionListModel> SearchByTextOrByDescription(string? textQuery, string? descriptionQuery)
    {
        List<QuestionEntity> entities = [];

        if (textQuery != null)
        {
            entities.AddRange(repository.SearchByText(textQuery) ?? []);
        }

        if (descriptionQuery != null)
        {
            entities.AddRange(repository.SearchByDescription(descriptionQuery) ?? []);
        }

        return mapper.Map<List<QuestionListModel>>(entities);
    }
}