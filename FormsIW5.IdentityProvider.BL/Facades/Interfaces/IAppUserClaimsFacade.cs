using FormsIW5.IdentityProvider.BL.Models.AppUserClaim;

namespace FormsIW5.IdentityProvider.BL.Facades.Interfaces;

public interface IAppUserClaimsFacade : IIdentityFacade
{
    Task<IEnumerable<AppUserClaimListModel>> GetAppUserClaimsByUserIdAsync(Guid userId);
}
