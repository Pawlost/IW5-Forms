using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Interfaces;
using FormsIW5.Common.BL.Models.User;

namespace FormsIW5.Api.BL.Facades;

public class UserFacade : FacadeBase<UserEntity, UserListModel, UserDetailModel, IUserRepository>, IUserFacade
{
    public UserFacade(IUserRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<ICollection<UserListModel>> SearchByNameAsync(string userNameQuery)
    {
        var entities = await repository.SearchByNameAsync(userNameQuery);
        return mapper.Map<List<UserListModel>>(entities);
    }
}
