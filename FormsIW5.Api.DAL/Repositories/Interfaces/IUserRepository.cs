using FormsIW5.Api.DAL.Entities;

namespace FormsIW5.Api.DAL.Repositories.Interfaces;

public interface IUserRepository : IApiRepository<UserEntity>
{
    public ICollection<UserEntity>? SearchByName(string userNameQuery);
}
