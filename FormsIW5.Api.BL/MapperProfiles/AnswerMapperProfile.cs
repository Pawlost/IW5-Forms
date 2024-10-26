using AutoMapper;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Common.BL.Models.Answer;

namespace FormsIW5.Api.BL.MapperProfiles;

public class AnswerMapperProfile : Profile
{
    public AnswerMapperProfile() 
    {
        CreateMap<AnswerEntity, AnswerListModel>();
        CreateMap<AnswerEntity, AnswerDetailModel>().ReverseMap();
        CreateMap<AnswerCreateModel, AnswerEntity>();

    }
}
