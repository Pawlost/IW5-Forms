using AutoMapper;
using FormsIW5.Api.DAL.Entities;
using FormsIW5.Common.BL.Models.Form;
using FormsIW5.Common.BL.Models.Question;
using FormsIW5.Common.BL.Models.User;

namespace FormsIW5.Api.BL.MapperProfiles;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<UserEntity, UserListModel>();
        CreateMap<UserEntity, UserDetailModel>().ReverseMap();
    }
}
