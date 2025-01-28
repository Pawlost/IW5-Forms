using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Queries;
using FormsIW5.Api.DAL.Common.Repositories;
using FormsIW5.BL.Models.Common.Answer;

namespace FormsIW5.Api.BL.Facades;

public class AnswerFacade : FacadeBase<AnswerEntity, AnswerListModel, AnswerDetailModel, AnswerCreateModel, IAnswerRepository>, IAnswerFacade
{
    public AnswerFacade(IAnswerRepository repository, IMapper mapper, IQuestionRepository questionRepository) : base(repository, mapper)
    {
    }

    public async Task<bool> HasQuestionUserAnswer(Guid questionId, OwnerQueryObject ownerQuery) {
        return await repository.HasQuestionUserAnswer(questionId, ownerQuery.OwnerId);
    }

    public async Task<AnswerDetailModel> GetUserAnswer(Guid questionId, OwnerQueryObject ownerQuery)
    {

        var answerEntity = await repository.GetUserAnswerAsync(questionId, ownerQuery.OwnerId);
        return mapper.Map<AnswerDetailModel>(answerEntity);
    }

    public override async Task<Guid?> UpdateAsync(AnswerDetailModel detailModel, OwnerQueryObject ownerQuery)
    {
        var entity = mapper.Map<AnswerEntity>(detailModel);


        if (await ExistsAsync(detailModel.Id))
        {
            if (ownerQuery.IsAdmin is not true)
            {
                entity.OwnerId = ownerQuery.OwnerId;
            }

            await ThrowIfWrongOwnerAsync(detailModel.Id, ownerQuery);
            return await repository.UpdateAsync(entity);
        }
        else
        {
            entity.OwnerId = ownerQuery.OwnerId;
            return await repository.InsertAsync(entity);
        }
    }
}
