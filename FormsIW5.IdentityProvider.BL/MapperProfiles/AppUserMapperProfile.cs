using AutoMapper;
using FormsIW5.BL.Models.Common.User;
using FormsIW5.IdentityProvider.DAL.Entities;

namespace FormsIW5.IdentityProvider.BL.MapperProfiles;

public class AppUserMapperProfile : Profile
{
    public AppUserMapperProfile()
    {
        CreateMap<AppUserCreateModel, AppUserEntity>();
        CreateMap<AppUserEntity, AppUserDetailModel>();
        CreateMap<AppUserEntity, AppUserListModel>();
    }
}
