using Duende.IdentityServer.Services;
using FormsIW5.BL.Models.Common.User;
using FormsIW5.IdentityProvider.BL.Facades;
using FormsIW5.IdentityProvider.BL.Facades.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FormsIW5.IdentityProvider.App.Pages.ManageUsers;

public class Index : PageModel
{
    [Parameter]
    public Guid Id { get; set; }

    [Inject]
    private AppUserFacade UserFacade { get; set; } = null!;

    private ICollection<AppUserListModel> Users { get; set; } = [];

    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    private string UsernameSearch { get; set; } = "";

    private bool UserCreated { get; set; } = false;

    private AppUserCreateModel NewUser { get; set; } = new();

    private readonly IIdentityServerInteractionService _interaction;
    private readonly IAppUserManagerFacade appUserFacade;

    public Index(
        IIdentityServerInteractionService interaction,
        IAppUserManagerFacade appUserFacade)
    {
        _interaction = interaction;
        this.appUserFacade = appUserFacade;
    }

    public IActionResult OnGet(string? returnUrl)
    {
        return Page();
    }

    public async Task CreateUserAsync() 
    {
        //await UserFacade.CreateUserAsync(NewUser);
        //Users = await UserFacade.SearchUserAsync(UsernameSearch);
        //NewUser = new();
    }

    public void OnUserDelete(Guid userId) 
    {
        var user = Users.First(u => u.Id == userId);
        Users.Remove(user);
    }

    public async Task SearchUser() 
    {
        //Users = await UserFacade.SearchUserAsync(UsernameSearch);
    }

    public void Back()
    {
        navigationManager.NavigateTo($"/forms/{Id}");
    }
}
