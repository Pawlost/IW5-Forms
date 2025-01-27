using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Repositories;
using FormsIW5.BL.Models.Common.Answer;

namespace FormsIW5.Api.BL.Facades;

public class AnswerFacade : FacadeBase<AnswerEntity, AnswerListModel, AnswerDetailModel, AnswerCreateModel, IAnswerRepository>, IAnswerFacade
{
    public AnswerFacade(IAnswerRepository repository, IMapper mapper, IQuestionRepository questionRepository) : base(repository, mapper)
    {
    }

    public async Task<bool> HasQuestionUserAnswer(Guid questionId, string? userId) {
        return await repository.HasQuestionUserAnswer(questionId, userId);
    }

    public async Task<AnswerDetailModel> GetUserAnswer(Guid questionId, string? userId)
    {

        var answerEntity = await repository.GetUserAnswerAsync(questionId, userId);
        return mapper.Map<AnswerDetailModel>(answerEntity);
    }

    public override async Task<Guid?> UpdateAsync(AnswerDetailModel detailModel, string? ownerId)
    {
        var entity = mapper.Map<AnswerEntity>(detailModel);
        entity.OwnerId = ownerId;

        if (await ExistsAsync(detailModel.Id))
        {
            await ThrowIfWrongOwnerAsync(detailModel.Id, ownerId);
            return await repository.UpdateAsync(entity);
        }
        else
        {
            return await repository.InsertAsync(entity);
        }
    }
}
