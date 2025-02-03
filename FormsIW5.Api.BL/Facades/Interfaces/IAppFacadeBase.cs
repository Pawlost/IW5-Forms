using FormsIW5.Api.BL.Queries;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IAppFacadeBase
{
    Task DeleteAsync(Guid id, OwnerQueryParameters userQuery);
    Task<bool> ExistsAsync(Guid id);
}
