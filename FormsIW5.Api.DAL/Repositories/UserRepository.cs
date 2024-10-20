using AutoMapper;
using FormsIW5.Api.DAL.Entities;
using FormsIW5.Api.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace FormsIW5.Api.DAL.Repositories;

public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
{
    public UserRepository(
        FormsIW5DbContext dbContext)
    : base(dbContext) {}

    public virtual async Task<ICollection<UserEntity>?> SearchByNameAsync(string nameQuery)
    {
        return await dbContext.Set<UserEntity>().Where(x => x.UserName.Contains(nameQuery)).ToListAsync();
    }
}
