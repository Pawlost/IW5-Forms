using FormsIW5.Common.BL.Models;
using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Api.BL.Facades.Interfaces
{
    public interface IListFacade<TListModelBase> : IAppFacadeBase
        where TListModelBase : IModel
    {
        ICollection<TListModelBase> GetAll();

        TListModelBase GetList(Guid id);
    }
}