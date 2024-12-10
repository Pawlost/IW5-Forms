using AutoMapper;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.BL.Models.Common.AnswerSelection;

namespace FormsIW5.Api.BL.MapperProfiles;

public class QuestionOptionMapperProfile : Profile
{
    public QuestionOptionMapperProfile() 
    {
        CreateMap<QuestionOptionEntity, QuestionOptionListModel>().ReverseMap();
        CreateMap<QuestionOptionEntity, QuestionOptionDetailModel>().ReverseMap();
        CreateMap<QuestionOptionCreateModel, QuestionOptionEntity>();
    }
}
