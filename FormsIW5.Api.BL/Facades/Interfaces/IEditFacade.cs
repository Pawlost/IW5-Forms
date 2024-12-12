using FormsIW5.BL.Models.Common.Interfaces;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IEditFacade<TEditModelBase> : IAppFacadeBase
    where TEditModelBase : IModel
{
    Task UpdateAsync(TEditModelBase editModel, string? ownerId);
}
