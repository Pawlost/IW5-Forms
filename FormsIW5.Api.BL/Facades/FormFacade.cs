using AutoMapper;
using FormsIW5.Api.DAL.Entities;
using FormsIW5.Api.DAL.Repositories.Interfaces;
using FormsIW5.Common.BL.Models.User;

namespace FormsIW5.Api.BL.Facades;

public class UserFacade : FacadeBase<UserEntity, UserListModel, UserDetailModel>
{
    public UserFacade(IApiRepository<UserEntity> recipeRepository, IMapper mapper) : base(recipeRepository, mapper)
    {
    }
}
