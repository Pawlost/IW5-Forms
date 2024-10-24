using AutoMapper;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Common.BL.Models.User;

namespace FormsIW5.Api.BL.MapperProfiles;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<UserEntity, UserListModel>().ReverseMap();
        CreateMap<UserEntity, UserDetailModel>().ReverseMap();
    }
}
