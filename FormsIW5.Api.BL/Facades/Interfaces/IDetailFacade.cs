using FormsIW5.BL.Models.Common.Interfaces;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IDetailFacade<TDetailModelBase> : IAppFacadeBase
    where TDetailModelBase : IModel
{
    Task<TDetailModelBase?> GetByIdAsync(Guid id);
    Task<Guid?> UpdateAsync(TDetailModelBase detailModel);
}