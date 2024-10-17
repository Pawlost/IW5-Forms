using AutoMapper;
using FormsIW5.Api.DAL.Entities;
using FormsIW5.Common.BL.Models.Form;
using FormsIW5.Common.BL.Models.Question;
using FormsIW5.Common.BL.Models.User;

namespace FormsIW5.Api.BL.MapperProfiles;

public class QuestionMapperProfile : Profile
{
    public QuestionMapperProfile()
    {
        CreateMap<QuestionEntity, QuestionListModel>();
        CreateMap<QuestionEntity, QuestionDetailModel>().ReverseMap().ForMember(dst => dst.Id, opt => opt.Ignore());
    }
}
