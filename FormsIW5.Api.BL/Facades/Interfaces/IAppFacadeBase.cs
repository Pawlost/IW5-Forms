namespace FormsIW5.Api.BL.Facades.Interfaces;

// This interface allows simple use of scrutor
public interface IAppFacadeBase
{
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);

}