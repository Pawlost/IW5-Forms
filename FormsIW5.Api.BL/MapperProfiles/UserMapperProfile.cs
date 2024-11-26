using AutoMapper;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.BL.Models.Common.User;

namespace FormsIW5.Api.BL.MapperProfiles;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<UserEntity, UserListModel>();
        CreateMap<UserEntity, UserDetailModel>().ReverseMap();
        CreateMap<UserCreateModel, UserEntity>();
    }
}