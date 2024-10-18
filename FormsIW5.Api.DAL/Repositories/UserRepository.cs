using AutoMapper;
using FormsIW5.Api.DAL.Entities;

namespace FormsIW5.Api.DAL.Repositories;

public class UserRepository : RepositoryBase<UserEntity>
{
    public UserRepository(
        FormsIW5DbContext dbContext)
        : base(dbContext)
    {
    }
}
