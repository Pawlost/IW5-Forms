using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IDetailFacade<TDetailModelBase> : IAppFacadeBase
    where TDetailModelBase : IModel
{
    Task<TDetailModelBase?> GetByIdAsync(Guid id);
    Task<Guid> CreateOrUpdateAsync(TDetailModelBase detailModel);
    Task<Guid> CreateAsync(TDetailModelBase detailModel);
    Task<Guid?> UpdateAsync(TDetailModelBase detailModel);
}