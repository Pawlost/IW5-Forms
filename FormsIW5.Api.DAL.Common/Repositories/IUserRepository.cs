using FormsIW5.Api.DAL.Entities;

namespace FormsIW5.Api.DAL.Common.Interfaces;

public interface IUserRepository : IApiRepository<UserEntity>
{
    public Task<ICollection<UserEntity>?> SearchByNameAsync(string userNameQuery);
}
