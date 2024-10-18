using FormsIW5.Common.BL.Models;

namespace FormsIW5.Api.BL.Facades.Interfaces
{
    public interface IAppFacade<TListModelBase, TDetailModelBase> : IAppFacadeBase
        where TListModelBase : ListModelBase
        where TDetailModelBase : DetailModelBase
    {
        List<TListModelBase> GetAll();
        TDetailModelBase? GetById(Guid id);
        Guid CreateOrUpdate(TDetailModelBase detailModel);
        Guid Create(TDetailModelBase detailModel);
        Guid? Update(TDetailModelBase detailModel);
        void Delete(Guid id);
    }
}