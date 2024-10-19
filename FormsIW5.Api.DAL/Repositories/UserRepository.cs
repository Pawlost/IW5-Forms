using AutoMapper;
using FormsIW5.Api.DAL.Entities;
using FormsIW5.Api.DAL.Repositories.Interfaces;
namespace FormsIW5.Api.DAL.Repositories;

public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
{
    public UserRepository(
        FormsIW5DbContext dbContext)
    : base(dbContext) {}

    public virtual ICollection<UserEntity>? SearchByName(string nameQuery)
    {
        return dbContext.Set<UserEntity>().Where(x => x.UserName.Contains(nameQuery)).ToList();
    }
}
