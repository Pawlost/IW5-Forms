using FormsIW5.BL.Models.Common.Form;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components;

public partial class FormCreateComponent
{
    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    [Inject]
    private FormFacade formFacade { get; set; } = null!;
    public async Task CreateDraftAsync()
    {
        FormCreateModel createModel = new FormCreateModel
        {
            FormName = "DraftForm",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now
        };

        var formId = await formFacade.FormPostAsync(createModel);
        navigationManager.NavigateTo($"/createForm/{formId}");
    }
}
