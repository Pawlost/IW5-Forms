using FormsIW5.BL.Models.Common.User;

namespace FormsIW5.IdentityProvider.BL.Common.Facades.Interfaces;

public interface IAppUserFacade 
{
    Task<Guid?> CreateAppUserAsync(AppUserCreateModel appUserModel, CancellationToken cancellationToken);
    Task<Guid> GetUserIdByUserNameAsync(string userName, CancellationToken cancellationToken);
    public Task<AppUserDetailModel?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<IList<AppUserListModel>> SearchAsync(string searchString);
    Task<AppUserDetailModel?> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken);
    Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken);
}
