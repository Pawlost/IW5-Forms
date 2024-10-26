using AutoMapper;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Common.BL.Models.Question;

namespace FormsIW5.Api.BL.MapperProfiles;

public class QuestionMapperProfile : Profile
{
    public QuestionMapperProfile()
    {
        CreateMap<QuestionEntity, QuestionListModel>();
        CreateMap<QuestionEntity, QuestionDetailModel>().ReverseMap();
        CreateMap<QuestionCreateModel, QuestionEntity>();
    }
}
