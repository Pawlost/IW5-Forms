using FormsIW5.BL.Models.Common.Form;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Pages.Forms;

public partial class FormCreatePage
{
    [Parameter]
    public Guid Id { get; set; } = Guid.Empty;

    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    [Inject]
    private FormFacade formFacade { get; set; } = null!;

    public async Task CreateDraftAsync()
    {
        var createModel = FormCreateModel.Empty;
        createModel.FormName = "New Form Draft";

        var formId = await formFacade.FormPostAsync(createModel);
        navigationManager.NavigateTo($"/forms/create/{formId}");
    }
}
