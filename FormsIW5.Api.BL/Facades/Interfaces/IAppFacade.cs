using FormsIW5.Common.BL.Models;

namespace FormsIW5.Api.BL.Facades.Interfaces
{
    public interface IAppFacade<TListModelBase, TDetailModelBase>
        where TListModelBase : ListModelBase
        where TDetailModelBase : DetailModelBase
    {
        List<TListModelBase> GetAll();
        TDetailModelBase? GetById(Guid id);
        Guid CreateOrUpdate(TDetailModelBase detailModeel);
        Guid Create(TDetailModelBase detailModeel);
        Guid? Update(TDetailModelBase detailModeel);
        void Delete(Guid id);
    }
}