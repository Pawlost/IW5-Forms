using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface ICreateFacade<TCreateModelBase> : IAppFacadeBase
    where TCreateModelBase : ICreateModel
{
    Task<Guid> CreateAsync(TCreateModelBase detailModel);
}