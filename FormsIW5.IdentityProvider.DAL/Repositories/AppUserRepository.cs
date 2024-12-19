using FormsIW5.IdentityProvider.DAL.Entities;
using FormsIW5.IdentityProvider.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.IdentityProvider.DAL.Repositories;

public class AppUserRepository(IdentityProviderDbContext identityProviderDbContext) : IAppUserRepository
{
    public async Task<IList<AppUserEntity>> SearchAsync(string searchString)
        => await identityProviderDbContext.Users.Where(user => EF.Functions.Like(user.UserName, $"%{searchString}%"))
        .ToListAsync();
}
