using AutoMapper;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.BL.Models.Common.Question;

namespace FormsIW5.Api.BL.MapperProfiles;

public class QuestionMapperProfile : Profile
{
    public QuestionMapperProfile()
    {
        CreateMap<QuestionEntity, QuestionListModel>().ReverseMap();
        CreateMap<QuestionEntity, QuestionDetailModel>().ReverseMap();
        CreateMap<QuestionCreateModel, QuestionEntity>();
    }
}
