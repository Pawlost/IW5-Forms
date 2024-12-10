namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IAppFacadeBase
{
    Task DeleteAsync(Guid id, string? ownerId);
    Task<bool> ExistsAsync(Guid id);
}
