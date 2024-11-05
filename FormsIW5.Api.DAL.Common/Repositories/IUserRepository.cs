using FormsIW5.Api.DAL.Common.Entities;

namespace FormsIW5.Api.DAL.Common.Repositories;

public interface IUserRepository : IApiRepository<UserEntity>
{
    public Task<ICollection<UserEntity>> SearchByNameAsync(string userNameQuery);

    public Task<bool> UserNameExistsAsync(string username);
}
