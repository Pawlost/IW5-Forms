using FormsIW5.IdentityProvider.DAL.Entities;

namespace FormsIW5.IdentityProvider.DAL.Repositories.Interfaces;

public interface IAppUserRepository
{
    Task<IList<AppUserEntity>> SearchAsync(string searchString);
}
