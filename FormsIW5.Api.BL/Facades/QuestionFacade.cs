﻿using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.BL.Queries;
using FormsIW5.Api.DAL.Common.DTO;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Repositories;
using FormsIW5.BL.Models.Common.Question;

namespace FormsIW5.Api.BL.Facades;

public class QuestionFacade : FacadeBase<QuestionEntity, QuestionEditModel, QuestionDetailModel, QuestionCreateModel, IQuestionRepository>, IQuestionFacade
{
    public QuestionFacade(IQuestionRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<ICollection<QuestionListModel>> SearchByText(QuestionQueryDTO questionQuery)
    {
        var result = await repository.SearchByText(questionQuery);
        return mapper.Map<List<QuestionListModel>>(result);
    }

    public async Task<ICollection<QuestionListModel>> SearchByDescription(QuestionQueryDTO questionQuery)
    {
        var result = await repository.SearchByDescription(questionQuery);
        return mapper.Map<List<QuestionListModel>>(result);
    }

    public async Task UpdateListQuestion(QuestionEditModel model, OwnerQueryParameters ownerQuery)
    {
        var entity = mapper.Map<QuestionEntity>(model);
        entity.OwnerId = ownerQuery.OwnerId;
        foreach (var questionOption in entity.QuestionOptions)
        {
            questionOption.OwnerId = ownerQuery.OwnerId;
        }
        await repository.UpdateAsync(entity);
    }

    public async Task<ICollection<Guid>> GetQuestionsIdsAsync(Guid formId)
    {
        return await repository.GetQuestionsIdsAsync(formId);
    }
}
