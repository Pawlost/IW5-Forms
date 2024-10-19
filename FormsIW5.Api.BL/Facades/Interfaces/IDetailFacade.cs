using FormsIW5.Common.BL.Models;
using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Api.BL.Facades.Interfaces
{
    public interface IDetailFacade<TDetailModelBase> : IAppFacadeBase
        where TDetailModelBase : IModel
    {
        TDetailModelBase? GetById(Guid id);
        Guid CreateOrUpdate(TDetailModelBase detailModel);
        Guid Create(TDetailModelBase detailModel);
        Guid? Update(TDetailModelBase detailModel);
    }
}