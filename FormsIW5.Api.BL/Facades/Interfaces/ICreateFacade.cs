using FormsIW5.BL.Models.Common.Interfaces;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface ICreateFacade<TCreateModelBase> : IAppFacadeBase
    where TCreateModelBase : ICreateModel
{
    Task<Guid> CreateAsync(TCreateModelBase detailModel);
}