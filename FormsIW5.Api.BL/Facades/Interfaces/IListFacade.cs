using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IListFacade<TListModelBase> : IAppFacadeBase
    where TListModelBase : IModel
{
    Task<ICollection<TListModelBase>> GetAllAsync();

    Task<TListModelBase> GetSingleListModelByIdAsync(Guid id);
}