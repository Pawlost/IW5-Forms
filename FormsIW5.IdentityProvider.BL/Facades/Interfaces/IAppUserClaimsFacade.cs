using FormsIW5.BL.Models.Common.User;

namespace FormsIW5.IdentityProvider.BL.Facades.Interfaces;

public interface IAppUserClaimsFacade : IIdentityFacade
{
    Task<IEnumerable<AppUserClaimListModel>> GetAppUserClaimsByUserIdAsync(Guid userId);
}
