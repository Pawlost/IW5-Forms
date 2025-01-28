using FormsIW5.Api.DAL.Common.Queries;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IAppFacadeBase
{
    Task DeleteAsync(Guid id, OwnerQueryObject userQuery);
    Task<bool> ExistsAsync(Guid id);
}
