using FormsIW5.Common.BL.Models.User;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IUserFacade : IDetailFacade<UserDetailModel>, IListFacade<UserListModel>
{
    Task<ICollection<UserListModel>> SearchByNameAsync(string userNameQuery);
    Task<bool> UserNameExistsAsync(string userName);

}
