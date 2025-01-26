using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Repositories;
using FormsIW5.BL.Models.Common.Answer;
using FormsIW5.BL.Models.Common.Form;

namespace FormsIW5.Api.BL.Facades;

public class FormFacade : FacadeBase<FormEntity, FormListModel, FormEditModel, FormCreateModel, IFormRepository>, IFormFacade
{
    private IAnswerRepository answerRepository;
    public FormFacade(IFormRepository repository, IMapper mapper, IAnswerRepository answerRepository) : base(repository, mapper)
    {
        this.answerRepository = answerRepository;
    }

    public async Task<FormDetailModel?> GetFormDetailByOwnerIdAsync(Guid id, string? ownerId)
    {
        var entity = await repository.GetFormDetailAsync(id);
        var formDetail = mapper.Map<FormDetailModel>(entity);

        formDetail.IsOwner = false;

        if (ownerId != null)
        {
            formDetail.IsOwner = entity?.OwnerId == ownerId;

            foreach (var question in formDetail.Questions) 
            {
                var answerEntity = await answerRepository.GetAnswerByOwnerIdAsync(question.Id, ownerId);
                question.Answer = mapper.Map<AnswerDetailModel>(answerEntity);
            }
        }

        return formDetail;
    }
}
