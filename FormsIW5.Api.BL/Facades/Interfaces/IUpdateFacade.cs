using FormsIW5.Api.DAL.Common.Queries;
using FormsIW5.BL.Models.Common.Interfaces;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IUpdateFacade<TDetailModelBase> : IAppFacadeBase
    where TDetailModelBase : IModel
{
    Task<TDetailModelBase?> GetByIdAsync(Guid id);
    Task<Guid?> UpdateAsync(TDetailModelBase model, OwnerQueryObject userQuery);
}
