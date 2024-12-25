using FormsIW5.BL.Models.Common.User;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components.Users;

public partial class UserComponent
{
    [Parameter]
    public required AppUserListModel User { get; set; }

    [Inject]
    private UserFacade userFacade { get; set; } = null!;

    [Parameter]
    public required EventCallback<Guid> OnDelete { get; set; }

    public async Task DeleteQuestionOptionAsync()
    {
        await userFacade.DeleteUserAsync(User.Id);
        await OnDelete.InvokeAsync(User.Id);
    }
}
