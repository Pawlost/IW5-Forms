using FormsIW5.Api.DAL.Entities;
using FormsIW5.Common.BL.Models.User;

namespace FormsIW5.Api.BL.Facades.Interfaces
{
    public interface IUserFacade : IDetailFacade<UserDetailModel>, IListFacade<UserListModel>
    {
        ICollection<UserListModel> SearchByName(string userNameQuery);
    }
}
