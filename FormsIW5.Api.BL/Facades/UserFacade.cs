using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Entities;
using FormsIW5.Api.DAL.Entities.Interfaces;
using FormsIW5.Api.DAL.Repositories.Interfaces;
using FormsIW5.Common.BL.Models.Form;
using FormsIW5.Common.BL.Models.Question;
using FormsIW5.Common.BL.Models.User;

namespace FormsIW5.Api.BL.Facades;

public class UserFacade : FacadeBase<UserEntity, UserListModel, UserDetailModel, IUserRepository>, IUserFacade
{
    public UserFacade(IUserRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public ICollection<UserListModel> SearchByName(string userNameQuery)
    {
        var entities = repository.SearchByName(userNameQuery);
        return mapper.Map<List<UserListModel>>(entities);
    }
}
