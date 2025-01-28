using System.Security.Claims;
using Blazored.FluentValidation;
using FormsIW5.BL.Models.Common.Form;
using FormsIW5.Web.BL;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace FormsIW5.Web.App.Pages.Forms;

public partial class FormDetailPage
{

    [Parameter]
    public Guid Id { get; set; }

    private FormDetailModel Model = new();

    [Inject]
    private FormFacade FormFacade { get; set; } = null!;

    [Inject]
    private UtilsFacade UtilsFacade { get; set; } = null!;

    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    [CascadingParameter]
    private Task<AuthenticationState> authStateTask { get; set; } = null!;

    private bool IsAdmin { get; set; }
    protected override async Task OnInitializedAsync()
    {
        var authState = await authStateTask;
        string clientName = authState.User?.Identity?.IsAuthenticated is true ? clientName = ClientNames.LogInApiClientName : clientName = ClientNames.AnonymousClientName;

        IsAdmin = await UtilsFacade.IsAdmin(clientName);
        Model = await FormFacade.GetDetailAsync(Id, clientName);

        await base.OnInitializedAsync();
    }

    public void Edit()
    {
        navigationManager.NavigateTo($"/forms/create/{Model.Id}");
    }
    public void ShowAnswers()
    {
        navigationManager.NavigateTo($"/questions/search/{Model.Id}");
    }
    public void Back()
    {
        navigationManager.NavigateTo($"/");
    }

    public async Task DeleteAsync() {
        await FormFacade.FormDeleteAsync(Id);
        Back();
    }
}
