using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Repositories;
using Microsoft.EntityFrameworkCore;
namespace FormsIW5.Api.DAL.Repositories;

public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
{
    public UserRepository(
        FormsIW5DbContext dbContext)
    : base(dbContext) {}

    public virtual async Task<ICollection<UserEntity>> SearchByNameAsync(string nameQuery)
    {
        return await dbContext.Set<UserEntity>().Where(x => x.UserName.Contains(nameQuery)).ToListAsync();
    }

    public override async Task<UserEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<UserEntity>().Include(u => u.Forms).SingleOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task<bool> UserNameExistsAsync(string username)
    {
        return await dbContext.Set<UserEntity>().AnyAsync(entity => entity.UserName == username);
    }
}
