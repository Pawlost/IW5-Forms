using FormsIW5.BL.Models.Common.Interfaces;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IListFacade<TListModelBase> : IAppFacadeBase
    where TListModelBase : IModel
{
    Task<ICollection<TListModelBase>> GetAllAsync();

    Task<TListModelBase> GetSingleListModelByIdAsync(Guid id);
}